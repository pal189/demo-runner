using System;
using _Project.Scripts.Buffs;
using UnityEngine;

namespace _Project.Scripts.Effects
{
    [CreateAssetMenu(menuName = "Effects/ChangeSpeedBuffCreator", fileName = "ChangeSpeedBuffCreator")]
    class ChangeSpeedBuffCreator : BuffCreator
    {
        [SerializeField] private float _speedChange;

        public override void Create(BuffFactory factory)
        {
            factory.CreateBuff<SpeedBuff>();
        }
    }
}