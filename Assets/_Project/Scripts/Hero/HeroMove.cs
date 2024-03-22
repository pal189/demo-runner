using System;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Services.Inputs;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Hero
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

        private IInputService _inputService;
        private Tween _steerTween;
        private int _targetPositionIndex;

        private void Awake()
        {
            _inputService = Game.InputService;

            _targetPositionIndex = InitialPositionIndex;
            _inputService.OnSwipeLeft.Subscribe(_ => TrySteerLeft()).AddTo(this);
            _inputService.OnSwipeRight.Subscribe(_ => TrySteerRight()).AddTo(this);

            HeroAnimator.Move(0.7f);
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            movementVector += Physics.gravity;
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
            StartSteering();
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
            StartSteering();
        }

        private void StartSteering()
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