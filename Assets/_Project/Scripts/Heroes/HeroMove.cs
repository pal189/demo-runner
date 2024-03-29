using System;
using _Project.Scripts._Core.Services.Inputs;
using _Project.Scripts.Cameras;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Heroes
{
    /// <summary>
    /// Hero movement. It subscribes to the events from input and steers the hero accordingly.
    /// It also handles jumping and falling (now that methods are called directly by Buffs).
    /// </summary>
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour, IDisposable
    {
        public BoolReactiveProperty IsMoving = new BoolReactiveProperty();

        private const float MoveSpeed = 0.7f;

        [SerializeField] private Transform Hero;
        [SerializeField] private HeroAnimator HeroAnimator;

        [SerializeField] private float[] HeroHorizontalPositions = new float[3];
        [SerializeField] private int InitialPositionIndex = 2;
        [SerializeField] private float SteeringTolerance = 0.2f;
        [SerializeField] private float SteeringSpeed;
        [SerializeField] private float FloorHeight = 0;
        [SerializeField] private float JumpHeight = 5;
        [SerializeField] private float JumpSpeed = 0.7f;
        [SerializeField] private float FallSpeed = 2;

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
        private void Construct(IInputService inputService, ICameraService cameraService)
        {
            _inputService = inputService;
            
            _targetPositionIndex = InitialPositionIndex;
            _inputService.OnSwipeLeft.Subscribe(_ => TrySteerLeft()).AddTo(this);
            _inputService.OnSwipeRight.Subscribe(_ => TrySteerRight()).AddTo(this);
            
            cameraService.FollowHero(this);
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
                .OnKill(() => { _jumpTween = null; });

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
                .OnKill(() => { _fallTween = null; });

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
            IsMoving.Value = true;

            float timeToTarget = Math.Abs(HeroHorizontalPositions[_targetPositionIndex] - Hero.position.x) / SteeringSpeed;
            _steerTween = Hero
                .DOMoveX(HeroHorizontalPositions[_targetPositionIndex], timeToTarget)
                .OnComplete(() => IsMoving.Value = false)
                .OnKill(() => _steerTween = null);
        }

        private bool IsHeroNearTarget() =>
            Math.Abs(HeroHorizontalPositions[_targetPositionIndex] - Hero.position.x) < SteeringTolerance;

        private bool IsHeroSteering() =>
            _steerTween != null;

        public void Dispose()
        {
            IsMoving?.Dispose();
        }
    }
}