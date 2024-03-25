using UnityEngine.Rendering;
using Zenject;

namespace _Project.Scripts.Buffs
{
    public class BuffInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuffFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuffsController>()
                .AsSingle().NonLazy();
            
            Container.Bind<SpeedBuff>().AsTransient();
        }
    }
}