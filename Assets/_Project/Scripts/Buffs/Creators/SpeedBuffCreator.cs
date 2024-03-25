using UnityEngine;

namespace _Project.Scripts.Buffs.Creators
{
    [CreateAssetMenu(menuName = "BuffCreators/SpeedBuffCreator", fileName = "SpeedBuffCreator")]
    public class SpeedBuffCreator : BuffCreator<SpeedBuff>
    {
        [SerializeField] public float SpeedChange;
    }
}