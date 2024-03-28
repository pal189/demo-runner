using System;
using System.Collections.Generic;
using _Project.Scripts._Core.Audio;
using _Project.Scripts._Core.Services;
using _Project.Scripts._Core.Services.Factories;
using Zenject;

namespace _Project.Scripts._Core.GSM
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, ISimpleState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }

    /// <summary>
    /// The state machine that controls the game flow.
    /// </summary>
    public class GameStateMachine : IGameStateMachine, IInitializable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(ISceneLoader sceneLoader, IGameFactory factory, ICurtainService curtain, IAudioService audio)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, factory, curtain),
                [typeof(GameLoopState)] = new GameLoopState(audio)
            };
        }

        public void Enter<TState>() where TState : class, ISimpleState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;

        public void Initialize()
        {
            Enter<BootstrapState>();
        }
    }
}