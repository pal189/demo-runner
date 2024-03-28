using _Project.Scripts._Core.Audio;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Collectables
{
    public class CollectableSound : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        private IAudioService _audioService;

        [Inject]
        private void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void OnTriggerEnter(Collider other) =>
            _audioService.PlaySound(clip, transform.position);
    }
}