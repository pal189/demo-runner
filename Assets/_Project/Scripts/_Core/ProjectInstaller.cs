using System;
using _Project.Scripts._Core.GSM;
using _Project.Scripts._Core.Services;
using _Project.Scripts._Core.Services.AssetProviders;
using _Project.Scripts._Core.Services.Factories;
using _Project.Scripts._Core.Services.Inputs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts._Core
{
    /// <summary>
    ///  Configurates dependencies and services for the whole project.
    /// </summary>
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