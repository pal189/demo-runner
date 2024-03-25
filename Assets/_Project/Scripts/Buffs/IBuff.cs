using _Project.Scripts.Effects;
using UnityEngine;

namespace _Project.Scripts.Buffs
{
    public interface IBuff
    {
        IBuffCreator BuffCreator { get; set; }

        void Activate();
        void Tick(float delta);
    }

    public abstract class Buff : IBuff
    {
        private readonly BuffsController _controller;

        protected float Duration;
        public bool IsFinished;

        protected Buff(BuffsController controller)
        {
            _controller = controller;
            _controller.AddBuff(this);
        }

        public bool IsDurationStacked => BuffCreator.DurationStacked;

        public IBuffCreator BuffCreator { get; set; }

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
            if (IsDurationStacked || Duration <= 0)
            {
                Duration += BuffCreator.Duration;
            }
        }

        protected abstract void ApplyEffect();

        public void SetEffect(IBuffCreator buffCreator) => BuffCreator = buffCreator;

        public abstract void End();
    }
}

