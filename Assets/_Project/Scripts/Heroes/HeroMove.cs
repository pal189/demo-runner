using System;
using _Project.Scripts.Infrastructure.Inputs;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Heroes
{
    /// <summary>
    /// The class for the hero movement. It subscribes to the events from input and steers the hero accordingly.
    /// It also handles jumping and falling (now that methods are called directly by Buffs).
    /// </summary>
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour
    {
        private const float MoveSpeed = 0.7f;
        public Transform Hero;
        public HeroAnimator HeroAnimator;
        public CharacterController CharacterController;

        public float[] HeroHorizontalPositions = new float[3];
        public int InitialPositionIndex = 2;
        public float SteeringTolerance = 0.2f;
        public float SteeringSpeed;
        public float FloorHeight = 0;
        public float JumpHeight = 5;
        public float JumpSpeed = 0.7f;
        public float FallSpeed = 2;
        private Tween _fallTween;

        private IInputService _inputService;
        private Tween _jumpTween;
        private Tween _steerTween;

        private int _targetPositionIndex;

        private void Awake()
        {
            HeroAnimator.Move(MoveSpeed);
            Fall();
        }

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;

            _targetPositionIndex = InitialPositionIndex;
            _inputService.OnSwipeLeft.Subscribe(_ => TrySteerLeft()).AddTo(this);
            _inputService.OnSwipeRight.Subscribe(_ => TrySteerRight()).AddTo(this);
        }

        public void Fly()
        {
            if (_fallTween != null)
            {
                _fallTween.Kill();
                _fallTween = null;
            }
            
            if (Hero.position.y >= JumpHeight
                || _jumpTween != null)
                return;

            _fallTween.Kill();
            _jumpTween = Hero
                .DOMoveY(JumpHeight, Math.Abs(JumpHeight - Hero.position.y) / JumpSpeed)
                .OnComplete(() => HeroAnimator.MidAir())
                .OnKill(() =>
                {
                    _jumpTween = null;
                });

            HeroAnimator.Jump();
        }

        public void Fall()
        {
            if (_jumpTween != null)
            {
                _jumpTween.Kill();
                _jumpTween = null;
            }
            
            if (_fallTween != null)
                return;

            _fallTween = Hero
                .DOMoveY(FloorHeight, Math.Abs(Hero.position.y - FloorHeight) / FallSpeed)
                .OnComplete(() =>
                {
                    HeroAnimator.StopJumping();
                    HeroAnimator.Move(MoveSpeed);
                })
                .OnKill(() =>
                {
                    _fallTween = null;
                });
            
            HeroAnimator.Fall();
        }

        private void TrySteerLeft()
        {
            if (_targetPositionIndex <= 0)
                return;

            if (IsHeroNearTarget())
                _steerTween.Kill();

            if (IsHeroSteering())
                return;

            _targetPositionIndex--;
            Steer();
        }

        private void TrySteerRight()
        {
            if (_targetPositionIndex >= HeroHorizontalPositions.Length - 1)
                return;

            if (IsHeroNearTarget())
                _steerTween.Kill();

            if (IsHeroSteering())
                return;

            _targetPositionIndex++;
            Steer();
        }

        private void Steer()
        {
            float timeToTarget = Math.Abs(HeroHorizontalPositions[_targetPositionIndex] - Hero.position.x) / SteeringSpeed;
            _steerTween = Hero
                .DOMoveX(HeroHorizontalPositions[_targetPositionIndex], timeToTarget)
                .OnKill(() => _steerTween = null);
        }

        private bool IsHeroNearTarget() =>
            Math.Abs(HeroHorizontalPositions[_targetPositionIndex] - Hero.position.x) < SteeringTolerance;

        private bool IsHeroSteering() =>
            _steerTween != null;
    }
}