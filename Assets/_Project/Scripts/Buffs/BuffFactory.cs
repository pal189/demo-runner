using Zenject;

namespace _Project.Scripts.Buffs
{
    public interface IBuffFactory
    {
        T CreateBuff<T>() where T : IBuff;
    }

    public class BuffFactory : IBuffFactory
    {
        private readonly DiContainer _container;

        public BuffFactory(DiContainer container) =>
            _container = container;

        public T CreateBuff<T>() where T : IBuff =>
            _container.Resolve<T>();
    }
}


