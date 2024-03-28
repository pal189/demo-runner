using _Project.Scripts._Core.Audio;

namespace _Project.Scripts._Core.GSM
{
    /// <summary>
    /// The state that runs the game loop. Currently just a placeholder.
    /// </summary>
    public class GameLoopState : ISimpleState
    {
        private readonly IAudioService _audio;

        public GameLoopState(IAudioService audio)
        {
            _audio = audio;
        }

        public void Enter()
        {
            PlayLevelMusic();
        }

        public void Exit()
        {
            StopLevelMusic();
        }

        private void StopLevelMusic() => 
            _audio.StopMusic();

        private void PlayLevelMusic() => 
            _audio.PlayLevelTheme();
    }
}