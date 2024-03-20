using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider platformMarker)
    {
        GameObject platform = platformMarker.transform.parent.gameObject;
        Destroy(platform);
    }
}