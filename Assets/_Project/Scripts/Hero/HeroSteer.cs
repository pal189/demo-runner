using System;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Services;
using _Project.Scripts.Services.Inputs;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
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
        private Tween _steerTween;
        private int _targetPositionIndex;

        private void Awake()
        {
            _inputService = Game.InputService;
            _targetPositionIndex = InitialPositionIndex;
            
            _inputService.OnSwipeLeft.Subscribe(_=>Debug.Log("Swipe left")).AddTo(this);
            _inputService.OnSwipeRight.Subscribe(_=>Debug.Log("Swipe right")).AddTo(this);
        }

        private void Update()
        {
            // HandleSteeringMovement();
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

        // private void FixedUpdate()
        // {
        //     CharacterController.Move(new Vector3(HeroHorizontalPositions[_targetPositionIndex], Hero.position.y, Hero.position.z));
        // }

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