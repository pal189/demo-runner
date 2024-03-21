using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class Factory : IFactory
    {
        private const string PlatformsPath = "Platfroms/Platform prefabs";
        private readonly GameObject[] _platforms;

        public Factory()
        {
            _platforms = Resources.LoadAll<GameObject>(PlatformsPath);
        }

        //TODO [PP 21/03/24]: Make Random Service
        public GameObject CreatePlatform(Vector3 at) =>
            Object.Instantiate(_platforms[Random.Range(0, _platforms.Length)], at, Quaternion.identity);

        private GameObject Instantiate(string path) =>
            Object.Instantiate(Resources.Load<GameObject>(path));

        private GameObject Instantiate(string path, Vector3 at) => 
            Object.Instantiate(Resources.Load<GameObject>(path), at, Quaternion.identity);
    }
}