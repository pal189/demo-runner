﻿using UnityEngine;
using Zenject;

namespace _Project.Scripts.Data
{
    public interface ILevel
    {
        float CurrentSpeed { get; set; }
    }

    public class Level : MonoBehaviour, ILevel, IInitializable
    {
        private const float MinSpeed = 1;
        public float InitialSpeed;
        private float _currentSpeed;

        public void Initialize()
        {
            CurrentSpeed = InitialSpeed;
        }


        public float CurrentSpeed
        {
            get => _currentSpeed;
            set => _currentSpeed = Mathf.Max(value, MinSpeed);
        }
    }
}