using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.GSM
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly Factory _factory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, Factory factory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _factory = factory;
        }

        public async void Enter(string sceneName)
        {
            _sceneLoader.LoadSceneAsync(sceneName, OnLevelLoaded);
        }

        public void Exit()
        {
        }

        private void OnLevelLoaded()
        {
            _factory.CreateHero();
        }
    }
}