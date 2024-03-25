using _Project.Scripts.Heroes;
using _Project.Scripts.Infrastructure.AssetProviders;
using _Project.Scripts.Platforms;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        Hero CreateHero(Vector3 at, Transform parent = null);
        GameObject CreatePlatform(Vector3 at, Transform parent = null);
    }
    
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;
        private IGameFactory _gameFactoryImplementation;

        public GameFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            _container = container;
        }

        public Hero CreateHero(Vector3 at, Transform parent = null)
        {
            var prefab = _assetProvider.GetPrefab(AssetPaths.HeroPath);
            var hero = _container.InstantiatePrefabForComponent<Hero>(prefab, at, Quaternion.identity, parent);
            
            _container.BindInterfacesAndSelfTo<Hero>()
                .FromInstance(hero)
                .AsSingle();
            
            return hero;
        }

        public GameObject CreatePlatform(Vector3 at, Transform parent = null)
        {
            var prefab = _assetProvider.GetPrefab(AssetPaths.PlatformPaths[Random.Range(0, AssetPaths.PlatformPaths.Length)]);
            var platform = _container.InstantiatePrefab(prefab, at, Quaternion.identity, parent);
            // var platform = _container.i(prefab, at, Quaternion.identity, parent);
            
            return platform;
        }
    }
}