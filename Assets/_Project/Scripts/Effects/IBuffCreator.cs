using _Project.Scripts.Buffs;
using UnityEngine;

namespace _Project.Scripts.Effects
{
    public interface IBuffCreator
    {
        float Duration { get; }
        bool IsDurationStacked { get; }
        void Create(BuffFactory factory);
    }

    public abstract class BuffCreator : ScriptableObject
    {
        public abstract void Create(BuffFactory factory);
    }

    public abstract class BuffCreator<T> : BuffCreator, IBuffCreator where T : IBuff
    {
        [SerializeField] private float _duration;

        [SerializeField] private bool _isDurationStacked;

        public float Duration => _duration;
        public bool IsDurationStacked => _isDurationStacked;

        public override void Create(BuffFactory factory)
        {
            factory.CreateBuff<T>(this);
        }
    }
}