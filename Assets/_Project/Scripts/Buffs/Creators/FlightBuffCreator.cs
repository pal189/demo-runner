using _Project.Scripts.Buffs.Buffs;
using UnityEngine;

namespace _Project.Scripts.Buffs.Creators
{
    /// <summary>
    /// The buff creator for the flight buff.
    /// </summary>
    [CreateAssetMenu(menuName = "BuffCreators/FlightBuffCreator", fileName = "FlightBuffCreator")]
    public class FlightBuffCreator : BuffCreator<FlightBuff>
    {
    }
}