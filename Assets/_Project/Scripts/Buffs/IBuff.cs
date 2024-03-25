using _Project.Scripts.Effects;
using UnityEngine;

namespace _Project.Scripts.Buffs
{
    public interface IBuff
    {
        IBuffCreator IBuffCreator { get; }

        void Activate();
        void Tick(float delta);
        void Init(IBuffCreator buffCreator);

    }

    public abstract class Buff<T> : IBuff where T : IBuffCreator
    {
        private readonly BuffsController _controller;
        protected T BuffCreator;

        protected float Duration;
        public bool IsFinished;

        protected Buff(BuffsController controller)
        {
            _controller = controller;
        }
        public void Init(IBuffCreator buffCreator) => Init((T)buffCreator);
        public void Init(T buffCreator)
        {
            BuffCreator = buffCreator;
            _controller.AddBuff(this);
        }

        public bool IsDurationStacked => IBuffCreator.IsDurationStacked;

        public IBuffCreator IBuffCreator => BuffCreator;

        public void Tick(float delta)
        {
            Duration -= delta;

            if (Duration <= 0)
            {
                End();
                IsFinished = true;
            }
        }

        /**
     * Activates buff or extends duration if ScriptableBuff has IsDurationStacked or IsEffectStacked set to true.
     */
        public void Activate()
        {
            if (Duration <= 0)
            {
                ApplyEffect();
                Duration += IBuffCreator.Duration;
            }

            else if (IsDurationStacked)
            {
                Duration += IBuffCreator.Duration;
            }
        }

        public void End()
        {
            OnEnd();
            _controller.RemoveBuff(this);           
        }

        protected abstract void ApplyEffect();

        protected abstract void OnEnd();
    }
}