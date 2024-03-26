using UnityEngine;

namespace _Project.Scripts.Infrastructure.Inputs
{
    /// <summary>
    /// The service for standalone input.
    ///     
    public class StandaloneInputService : InputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        protected override Vector2 GetAxis()
        {
            Vector2 axis = base.GetAxis();
            return axis != Vector2.zero
                ? axis
                : UnityAxis();
        }

        private Vector2 UnityAxis() =>
            new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}