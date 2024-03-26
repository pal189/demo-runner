using _Project.Scripts.Buffs.Buffs;
using Zenject;

namespace _Project.Scripts.Buffs
{
    /// <summary>
    /// The installer for the buff system. Binds the buff factory ,the controller and all the buffs.
    /// Every new buff should be added here.
    /// </summary>
    public class BuffInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuffFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuffsController>()
                .AsSingle().NonLazy();
            
            Container.Bind<SpeedBuff>().AsTransient();
            Container.Bind<FlightBuff>().AsTransient();
        }
    }
}