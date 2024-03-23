using _Project.Scripts.Services.Inputs;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.GSM
{
    public class BootstrapState : IState
    {
        private const string BootstrapSceneName = "Bootstrap";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            InitDOTween();
            RegisterFactory();
            RegisterInputService();
            _sceneLoader.LoadSceneAsync(BootstrapSceneName, onLoaded: EnterLevel);
        }

        private void EnterLevel()
        {
            _stateMachine.Enter<LoadMainSceneState>();
        }


        public void Exit()
        {
        }


        private void InitDOTween() =>
            DOTween.Init(true, false, LogBehaviour.Verbose);

        private void RegisterInputService() =>
            Game.InputService = Application.isEditor
                ? new StandaloneInputService()
                : new MobileInputService();

        private static void RegisterFactory() =>
            Game.Factory = new Factory();
    }
}