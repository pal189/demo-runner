using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class Factory : IFactory
    {
        private const string PlatformsPath = "Platfroms/Platform";

        public GameObject CreatePlatform(Vector3 at) => Instantiate(PlatformsPath, at);
        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}