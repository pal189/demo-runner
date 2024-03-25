using _Project.Scripts.Data;
using _Project.Scripts.Effects;

namespace _Project.Scripts.Buffs
{
    public class SpeedBuff : Buff<SpeedBuffCreator>
    {
        private readonly ILevel _level;
        private float _change;

        public SpeedBuff(BuffsController controller, ILevel level) : base(controller)
        {
            _level = level;
        }

        protected override void ApplyEffect()
        {
            var oldSpeed = _level.CurrentSpeed;
            _level.CurrentSpeed += BuffCreator.SpeedChange;
            _change = _level.CurrentSpeed - oldSpeed;
        }

        protected override void OnEnd()
        {
            _level.CurrentSpeed -= _change;
        }
    }
}