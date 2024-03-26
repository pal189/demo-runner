using Zenject;

namespace _Project.Scripts.Data
{
    /// <summary>
    /// The installer for the level. Binds the level.
    /// </summary>
    public class LevelInstaller : MonoInstaller
    {
        public Level LevelInstance;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Level>().FromInstance(LevelInstance).AsSingle().NonLazy();
        }
    }
}