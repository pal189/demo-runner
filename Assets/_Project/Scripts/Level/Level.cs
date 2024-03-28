using UnityEngine;
using Zenject;

namespace _Project.Scripts.Level
{
    public interface ILevel
    {
        float CurrentSpeed { get; set; }
    }

    /// <summary>
    /// The level data (its global variables).
    /// </summary>
    public class Level : MonoBehaviour, ILevel, IInitializable
    {
        private const float MinSpeed = 1;
        public float InitialSpeed;
        private float _currentSpeed;

        public float CurrentSpeed
        {
            get => _currentSpeed;
            set => _currentSpeed = Mathf.Max(value, MinSpeed);
        }

        public void Initialize()
        {
            CurrentSpeed = InitialSpeed;
        }
    }
}