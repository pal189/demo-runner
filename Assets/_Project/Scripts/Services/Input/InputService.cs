using UnityEngine;

namespace _Project.Scripts.Services
{
    public abstract class InputService : IInputService
    {
        protected const string SwipeLeft = "SwipeLeft";
        protected const string SwipeRight = "SwipeRight";
        protected const string SwipeUp = "SwipeUp";
        protected const string SwipeDown = "SwipeDown";
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected static Vector2 SimpleInputAxis()
        {
            var horizontalInput = SimpleInput.GetAxis(SwipeRight) - SimpleInput.GetAxis(SwipeLeft);
            var verticalInput = SimpleInput.GetAxis(SwipeUp) - SimpleInput.GetAxis(SwipeDown);
            return new Vector2(horizontalInput, verticalInput);
        }
    }
}