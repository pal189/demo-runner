using _Project.Scripts.Infrastructure.GSM;
using _Project.Scripts.UI;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        public LoadingCurtain Curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(Curtain);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}