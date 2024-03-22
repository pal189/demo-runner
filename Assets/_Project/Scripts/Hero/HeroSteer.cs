using System;
using _Project.Scripts.Services;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Hero
{
    public class HeroSteer : MonoBehaviour
    {
        public Transform Hero;
        public float[] HeroHorizontalPositions = new float[3];
        public int InitialPositionIndex = 2;
        public float SteeringTime;
        public CharacterController CharacterController;

        private IInputService _inputService;
        private bool _isOldSwipe;
        private Tween _steerTween;
        private int _targetPositionIndex;

        private void Awake()
        {
            _inputService = Game.InputService;
            _targetPositionIndex = InitialPositionIndex;
        }

        private void Update()
        {
            UpdateTargetPositionIndex();
            HandleSteeringMovement();
        }

        private void UpdateTargetPositionIndex()
        {
            ResetOldSwipe();
            if (ShouldHandleSwipe())
                HandleSwipe();
        }

        private void ResetOldSwipe()
        {
            if (_inputService.Axis.x == 0)
                _isOldSwipe = false;
        }

        private bool ShouldHandleSwipe() =>
            !_isOldSwipe
            && _inputService.Axis.x != 0;

        private void HandleSwipe()
        {
            _isOldSwipe = true;
            float xAxis = _inputService.Axis.x;

            if (xAxis > 0 && _targetPositionIndex < HeroHorizontalPositions.Length - 1)
                _targetPositionIndex++;
            else if (xAxis < 0 && _targetPositionIndex > 0)
                _targetPositionIndex--;
        }

        private void HandleSteeringMovement()
        {
            // if (IsHeroOnTarget() || IsHeroSteering())
            if (IsHeroOnTarget())
                return;

            Steer();
        }

        private bool IsHeroOnTarget() =>
            Math.Abs(HeroHorizontalPositions[_targetPositionIndex] - Hero.position.x) < Mathf.Epsilon;

        private void FixedUpdate()
        {
            CharacterController.Move(new Vector3(HeroHorizontalPositions[_targetPositionIndex], Hero.position.y, Hero.position.z));
        }

        // private bool IsHeroSteering() =>
        //     _steerTween != null;

        private void Steer()
        {
            
            Vector3 movementVector = Vector3.zero;
            movementVector += Physics.gravity;

            // _steerTween?.Kill();
            // _steerTween = Hero.DOMoveX(HeroHorizontalPositions[_targetPositionIndex], SteeringTime).OnKill(() => _steerTween = null);
            
        }
    }
}