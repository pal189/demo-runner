using System;
using _Project.Scripts.Buffs;
using UnityEngine;

namespace _Project.Scripts.Effects
{
    [CreateAssetMenu(menuName = "BuffCreators/SpeedBuffCreator", fileName = "SpeedBuffCreator")]
    public class SpeedBuffCreator : BuffCreator<SpeedBuff>
    {
        [SerializeField] public float SpeedChange;
    }
}