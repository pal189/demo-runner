using _Project.Scripts.Buffs.Creators;
using _Project.Scripts.Heroes;

namespace _Project.Scripts.Buffs.Buffs
{
    /// <summary>
    /// The buff that makes the hero fly.
    /// </summary>
    public class FlightBuff : Buff<FlightBuffCreator>
    {
        private readonly HeroMove _heroMove;

        public FlightBuff(BuffsController controller, Hero hero) : base(controller)
        {
            _heroMove = hero.GetComponent<HeroMove>();
        }

        protected override void ApplyEffect()
        {
            _heroMove.Fly();
        }

        protected override void OnEnd()
        {
            _heroMove.Fall();
        }
    }
}