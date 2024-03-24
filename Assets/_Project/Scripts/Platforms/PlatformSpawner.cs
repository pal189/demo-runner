using _Project.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Platforms
{
    [RequireComponent(typeof(Collider))]
    public class PlatformSpawner : MonoBehaviour
    {
        private IGameFactory _factory;

        [Inject]
        public void Construct(IGameFactory factory) =>
            _factory = factory;
        
        private void OnTriggerEnter(Collider platformMarker) => 
            _factory.CreatePlatform(platformMarker.transform.position);
    }
}