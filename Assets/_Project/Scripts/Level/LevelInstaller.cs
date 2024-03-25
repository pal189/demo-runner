using _Project.Scripts.Infrastructure.Factories;
using Zenject;

namespace _Project.Scripts.Data
{
    public class LevelInstaller : MonoInstaller
    {
        public Level LevelInstance;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Level>().FromInstance(LevelInstance).AsSingle().NonLazy();
        }
    }
}