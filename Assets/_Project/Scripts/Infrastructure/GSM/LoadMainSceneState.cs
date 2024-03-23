namespace _Project.Scripts.Infrastructure.GSM
{
    public class LoadMainSceneState : IState
    {
        private const string MainSceneName = "Main";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadMainSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadSceneAsync(MainSceneName);
        }

        public void Exit()
        {
        }
    }
}