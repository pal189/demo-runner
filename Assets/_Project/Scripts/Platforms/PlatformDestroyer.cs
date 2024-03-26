using UnityEngine;

namespace _Project.Scripts.Platforms
{
    /// <summary>
    /// Destroys the platform when it collides with the platform marker.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PlatformDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider platformMarker)
        {
            GameObject platform = platformMarker.transform.parent.gameObject;
            Destroy(platform);
        }
    }
}