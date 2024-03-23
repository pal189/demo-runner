using _Project.Scripts.UI;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.GSM
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly Factory _factory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, Factory factory, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _factory = factory;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadSceneAsync(sceneName, OnLevelLoaded);
        }

        public void Exit() => 
            _loadingCurtain.Hide();

        private void OnLevelLoaded()
        {
            _factory.CreateHero();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}