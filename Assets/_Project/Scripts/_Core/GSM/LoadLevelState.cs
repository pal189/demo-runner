using _Project.Scripts._Core.Services;
using _Project.Scripts._Core.Services.Factories;
using UnityEngine;

namespace _Project.Scripts._Core.GSM
{
    /// <summary>
    /// The state that loads level scenes.
    /// </summary>
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string StartPointTag = "StartPoint";
        
        private readonly IGameFactory _factory;
        private readonly ICurtainService _curtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;

        public LoadLevelState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IGameFactory factory, ICurtainService curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _factory = factory;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.LoadSceneAsync(sceneName, OnLevelLoaded);
        }

        public void Exit() => 
            _curtain.Hide();

        private void OnLevelLoaded()
        {
            GameObject startPoint = GameObject.FindWithTag(StartPointTag);
            _factory.CreateHero(startPoint.transform.position, startPoint.transform);
            _stateMachine.Enter<GameLoopState>();
        }
    }
}