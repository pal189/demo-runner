using _Project.Scripts.Heroes;
using _Project.Scripts.Infrastructure.AssetProviders;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        Hero CreateHero(Vector3 at, Transform parent = null);
        GameObject CreatePlatform(Vector3 at);
    }
    
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;

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
            // return _assetProvider.Instantiate(AssetPaths.HeroPath, at);
        }

        public GameObject CreatePlatform(Vector3 at) =>
            _assetProvider.Instantiate(AssetPaths.PlatformPaths[Random.Range(0, AssetPaths.PlatformPaths.Length)], at);
    }
}