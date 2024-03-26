using DG.Tweening;

namespace _Project.Scripts.Infrastructure.GSM
{
    /// <summary>
    /// The state that bootstraps the game.
    /// </summary>
    public class BootstrapState : ISimpleState
    {
        private const string StartUpScene = "StartUp";
        private const string MainScene = "Main";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;

        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            InitDOTween();
            _sceneLoader.LoadSceneAsync(StartUpScene, onLoaded: EnterLevel);
        }


        public void Exit()
        {
        }

        private void EnterLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(MainScene);
        }


        private void InitDOTween() =>
            DOTween.Init(true, false, LogBehaviour.Verbose);
    }
}