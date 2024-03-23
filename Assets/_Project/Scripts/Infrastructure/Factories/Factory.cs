using _Project.Scripts.Infrastructure.AssetProviders;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class Factory : IFactory
    {
        private readonly IAssetProvider _assetProvider;

        public Factory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(Vector3 at) => 
             _assetProvider.Instantiate(AssetPaths.HeroPath, at);

        public GameObject CreatePlatform(Vector3 at) =>
            _assetProvider.Instantiate(AssetPaths.PlatformPaths[Random.Range(0, AssetPaths.PlatformPaths.Length)], at);
        
    }
}