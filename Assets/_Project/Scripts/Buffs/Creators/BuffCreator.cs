using _Project.Scripts.Buffs.Buffs;
using UnityEngine;

namespace _Project.Scripts.Buffs.Creators
{
    public interface IBuffCreator
    {
        float Duration { get; }
        bool IsDurationStacked { get; }
        void Create(BuffFactory factory);
    }

    /// <summary>
    /// Base class for buff creators. These are scriptable objects that can be added to BuffCcollectables and then be used by them
    /// to create buffs when collected.
    /// </summary>
    public abstract class BuffCreator : ScriptableObject
    {
        public abstract void Create(BuffFactory factory);
    }

    /// <summary>
    /// Generic version of BuffCreator which can be parametrized by specific Buff which should be created. It helps to avoid casting. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
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