using System;
using _Project.Scripts.Infrastructure.AssetProviders;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.GSM;
using _Project.Scripts.Infrastructure.Inputs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public CurtainService CurtainServicePrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CurtainService>()
                .FromComponentInNewPrefab(CurtainServicePrefab)
                .WithGameObjectName("Curtain")
                .UnderTransform(transform)
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<AssetProvider>()
                .AsSingle().NonLazy();
            
            Type inputServiceType = Application.isEditor
                ? typeof(StandaloneInputService)
                : typeof(MobileInputService);
            
            Container.BindInterfacesTo(inputServiceType)
                .AsSingle().NonLazy();
            
            Container.BindInterfacesTo<GameFactory>()
                .AsSingle()
                .CopyIntoDirectSubContainers()
                .NonLazy();
            
            Container.BindInterfacesTo<SceneLoader>()
                .AsSingle().NonLazy();
            
            Container.BindInterfacesTo<GameStateMachine>()
                .AsSingle().NonLazy();
        }
    }
}