using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            DontDestroyOnLoad(this);
        }
    }
}