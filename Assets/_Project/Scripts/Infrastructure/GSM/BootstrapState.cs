using _Project.Scripts.Services.Inputs;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.GSM
{
    public class BootstrapState : ISimpleState
    {
        private const string BootstrapSceneName = "Bootstrap";
        private const string MainSceneName = "Main";
        
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
            RegisterInputService();
            _sceneLoader.LoadSceneAsync(BootstrapSceneName, onLoaded: EnterLevel);
        }

        private void EnterLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(MainSceneName);
        }


        public void Exit()
        {
        }


        private void InitDOTween() =>
            DOTween.Init(true, false, LogBehaviour.Verbose);

        private void RegisterInputService()
        {
            Game.InputService = Application.isEditor
                ? new StandaloneInputService()
                : new MobileInputService();
        }
    }
}