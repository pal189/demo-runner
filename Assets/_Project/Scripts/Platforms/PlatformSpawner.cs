using _Project.Scripts._Core.Services.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Platforms
{
    /// <summary>
    /// Spawns next platform when collides with the platform marker of the previous platform.
    /// 
    [RequireComponent(typeof(Collider))]
    public class PlatformSpawner : MonoBehaviour
    {
        private IGameFactory _factory;

        [Inject]
        private void Construct(IGameFactory factory) =>
            _factory = factory;
        
        private void OnTriggerEnter(Collider platformMarker) => 
            _factory.CreatePlatform(platformMarker.transform.position);
    }
}