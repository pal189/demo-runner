using _Project.Scripts.Buffs;
using UnityEngine;

namespace _Project.Scripts.Effects
{
    public interface IBuffCreator
    {
        float Duration { get; }
        bool DurationStacked { get; }
        void Create(BuffFactory factory);
    }
    
    public abstract class BuffCreator : ScriptableObject, IBuffCreator
    {
        [SerializeField]
        private float _duration;

        [SerializeField]
        private bool _durationStacked;

        public float Duration => _duration;
        public bool DurationStacked => _durationStacked;
        
        public abstract void Create(BuffFactory factory);
    }
}