using System;
using _Project.Scripts._Core.Audio;
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
        private const string CurtainName = "Curtain";
        private const string AudioServiceName = "AudioService";
        public CurtainService CurtainServicePrefab;
        public AudioService AudioServicePrefab;
        public GameObject SimpleInputPrefab;

        public override void InstallBindings()
        {
            RegisterCurtainService();
            RegisterAssetProvider();
            SpawnSimpleInputObject();
            RegisterInputService();
            RegisterGameFactory();
            RegisterSceneLoader();
            RegisterAudioService();
            RegisterGSM();
        }

        private void RegisterCurtainService()
        {
            Container.BindInterfacesTo<CurtainService>()
                .FromComponentInNewPrefab(CurtainServicePrefab)
                .WithGameObjectName(CurtainName)
                .AsSingle().NonLazy();
        }

        private void RegisterAssetProvider()
        {
            Container.BindInterfacesTo<AssetProvider>()
                .AsSingle().NonLazy();
        }

        private void SpawnSimpleInputObject() => 
            Instantiate(SimpleInputPrefab);

        private void RegisterInputService()
        {
            Type inputServiceType = Application.isEditor
                ? typeof(StandaloneInputService)
                : typeof(MobileInputService);

            Container.BindInterfacesTo(inputServiceType)
                .AsSingle().NonLazy();
        }

        private void RegisterGameFactory()
        {
            Container.BindInterfacesTo<GameFactory>()
                .AsSingle()
                .CopyIntoDirectSubContainers()
                .NonLazy();
        }

        private void RegisterSceneLoader()
        {
            Container.BindInterfacesTo<SceneLoader>()
                .AsSingle().NonLazy();
        }

        private void RegisterAudioService()
        {
            Container.BindInterfacesTo<AudioService>()
                .FromComponentInNewPrefab(AudioServicePrefab)
                .WithGameObjectName(AudioServiceName)
                .AsSingle().NonLazy();
        }

        private void RegisterGSM()
        {
            Container.BindInterfacesTo<GameStateMachine>()
                .AsSingle().NonLazy();
        }
    }
}