using _Project.Scripts.Buffs.Buffs;
using _Project.Scripts.Buffs.Creators;
using Zenject;

namespace _Project.Scripts.Buffs
{
    public interface IBuffFactory
    {
        T CreateBuff<T>(IBuffCreator creator) where T : IBuff;
    }

    /// <summary>
    /// The factory that creates buffs. It resolves the buff and then passes its buff creator to it.
    /// </summary>
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


