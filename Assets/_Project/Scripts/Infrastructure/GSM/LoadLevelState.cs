using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.GSM
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string StartPointTag = "StartPoint";
        
        private readonly IFactory _factory;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IFactory factory, LoadingCurtain loadingCurtain)
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
            GameObject startPoint = GameObject.FindWithTag(StartPointTag);
            _factory.CreateHero(startPoint.transform.position);
            _stateMachine.Enter<GameLoopState>();
        }
    }
}