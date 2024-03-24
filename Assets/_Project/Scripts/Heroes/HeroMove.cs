using System;
using _Project.Scripts.Services.Inputs;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Heroes
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour
    {
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
            HeroAnimator.Move(0.7f);
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

        private void Fall()
        {
            if (_fallTween != null)
                return;

            _fallTween = Hero
                .DOMoveY(FloorHeight, Math.Abs(Hero.position.y - FloorHeight) / FallSpeed)
                .OnKill(() =>
                {
                    _fallTween = null;
                });
            
            HeroAnimator.StopJumping();
        }

        private void Jump()
        {
            if (Hero.position.y >= JumpHeight
                || _jumpTween != null)
                return;

            _fallTween.Kill();
            _jumpTween = Hero
                .DOMoveY(JumpHeight, Math.Abs(JumpHeight - Hero.position.y) / JumpSpeed)
                .OnKill(() =>
                {
                    _jumpTween = null;
                });

            HeroAnimator.Jump();
        }
        
        
    }
}