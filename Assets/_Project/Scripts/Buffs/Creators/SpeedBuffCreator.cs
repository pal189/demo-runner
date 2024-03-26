using _Project.Scripts.Buffs.Buffs;
using UnityEngine;

namespace _Project.Scripts.Buffs.Creators
{
    /// <summary>
    /// The buff creator for the speed buff.
    /// 
    [CreateAssetMenu(menuName = "BuffCreators/SpeedBuffCreator", fileName = "SpeedBuffCreator")]
    public class SpeedBuffCreator : BuffCreator<SpeedBuff>
    {
        [SerializeField] public float SpeedChange;
    }
}