using UnityEngine;

namespace _Project.Scripts.Platforms
{
    [RequireComponent(typeof(Collider))]
    public class PlatformSpawner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider platformMarker) => 
            Game.Factory.CreatePlatform(platformMarker.transform.position);
    }
}