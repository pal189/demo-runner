using UnityEngine;

namespace _Project.Scripts.Infrastructure.AssetProviders
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
        GameObject GetPrefab(string path);
    }
    
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) =>
            Object.Instantiate(Resources.Load<GameObject>(path));

        public GameObject Instantiate(string path, Vector3 at) => 
            Object.Instantiate(Resources.Load<GameObject>(path), at, Quaternion.identity);
        
        public GameObject GetPrefab(string path) =>
            Resources.Load<GameObject>(path);
    }
}