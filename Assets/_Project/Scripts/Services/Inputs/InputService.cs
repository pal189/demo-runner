using System;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Services.Inputs
{
    public interface IInputService
    {
        ReactiveCommand OnSwipeLeft { get; }
        ReactiveCommand OnSwipeRight { get; }
    }
    
    public abstract class InputService : IInputService, IDisposable
    {
        private const string SwipeLeft = "SwipeLeft";
        private const string SwipeRight = "SwipeRight";
        private const string SwipeUp = "SwipeUp";
        private const string SwipeDown = "SwipeDown";

        private bool _isOldSwipe;
        private Vector2 Axis;
        
        public ReactiveCommand OnSwipeLeft { get; private set; }
        public ReactiveCommand OnSwipeRight { get; private set; }

        protected InputService()
        {
            CreateObservables();
        }

        public void Dispose()
        {
            OnSwipeLeft.Dispose();
            OnSwipeRight.Dispose();
        }

        private void CreateObservables()
        {
            OnSwipeLeft = new ReactiveCommand();
            OnSwipeRight = new ReactiveCommand();
            Observable.EveryUpdate().Subscribe(_ => UpdateTargetPositionIndex());
        }

        private void UpdateTargetPositionIndex()
        {
            UpdateAxis();
            ResetOldSwipe();
            if (ShouldHandleSwipe())
                HandleSwipe();
        }

        private void UpdateAxis() =>
            Axis = GetAxis();

        protected virtual Vector2 GetAxis()
        {
            var horizontalInput = SimpleInput.GetAxis(SwipeRight) - SimpleInput.GetAxis(SwipeLeft);
            var verticalInput = SimpleInput.GetAxis(SwipeUp) - SimpleInput.GetAxis(SwipeDown);
            return new Vector2(horizontalInput, verticalInput);
        }

        private void ResetOldSwipe()
        {
            if (Axis.x == 0)
                _isOldSwipe = false;
        }

        private bool ShouldHandleSwipe() =>
            !_isOldSwipe
            && Axis.x != 0;

        private void HandleSwipe()
        {
            _isOldSwipe = true;

            if (Axis.x > 0)
                OnSwipeRight.Execute();
            else if (Axis.x < 0)
                OnSwipeLeft.Execute();
        }
    }
}