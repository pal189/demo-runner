using _Project.Scripts.Infrastructure.GSM;
using _Project.Scripts.Services.Inputs;
using _Project.Scripts.UI;

namespace _Project.Scripts.Infrastructure
{
    public class Game
    {
        public static IFactory Factory;
        public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(LoadingCurtain curtain)
        {
            Factory = new Factory();
            StateMachine = new GameStateMachine(new SceneLoader(), Factory, curtain);
        }
    }
}