using _Project.Scripts._Core.Services.Factories;
using _Project.Scripts.Cameras;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Level
{
    /// <summary>
    /// The installer for the level. Binds the level.
    /// </summary>
    public class LevelInstaller : MonoInstaller
    {
        public Level LevelInstance;
        public Camera Camera;
        private const string StartPointTag = "StartPoint";

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Level>().FromInstance(LevelInstance)
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<CameraService>()
                .AsSingle()
                .WithArguments(Camera)
                .NonLazy();
            
            SpawnHero();
        }

        private void SpawnHero()
        {
            GameObject startPoint = GameObject.FindWithTag(StartPointTag);
            var factory = Container.Resolve<IGameFactory>();
            factory.CreateHero(startPoint.transform.position);
        }
    }
}