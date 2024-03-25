using _Project.Scripts.Effects;
using Zenject;

namespace _Project.Scripts.Buffs
{
    public interface IBuffFactory
    {
        T CreateBuff<T>(IBuffCreator creator) where T : IBuff;
    }

    public class BuffFactory : IBuffFactory
    {
        private readonly DiContainer _container;

        public BuffFactory(DiContainer container) =>
            _container = container;

        public T CreateBuff<T>(IBuffCreator creator) where T : IBuff
        {
            var buff = _container.Resolve<T>();
            buff.Init(creator);
            return buff;
        }
    }
}


