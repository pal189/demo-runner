using UnityEngine;

namespace _Project.Scripts._Core.Audio
{
    public interface IAudioService
    {
        void PlaySound(AudioClip clip);
        void PlaySound(AudioClip clip, Vector3 at);
        void PlayLevelTheme();
        void StopMusic();
    }

    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioSource _SFXSource;
        [SerializeField] private AudioSource _musicSource;
        
        [SerializeField] private AudioClip _levelTheme;

        public void PlaySound(AudioClip clip) =>
            _SFXSource.PlayOneShot(clip);

        public void PlaySound(AudioClip clip, Vector3 at) =>
            AudioSource.PlayClipAtPoint(clip, at);
        
        public void PlayLevelTheme()
        {
            _musicSource.clip = _levelTheme;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        public void StopMusic() => 
            _musicSource.Stop();
    }
}