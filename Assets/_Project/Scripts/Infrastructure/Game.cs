using _Project.Scripts.Infrastructure.GSM;
using _Project.Scripts.Services.Inputs;

namespace _Project.Scripts.Infrastructure
{
    public class Game
    {
        public static Factory Factory;
        public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game()
        {
            Factory = new Factory();
            StateMachine = new GameStateMachine(new SceneLoader(), Factory);
        }
    }
}