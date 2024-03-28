using _Project.Scripts.Buffs.Creators;
using _Project.Scripts.Level;

namespace _Project.Scripts.Buffs.Buffs
{
    /// <summary>
    /// The buff that makes that changes game speed.
    /// </summary>
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