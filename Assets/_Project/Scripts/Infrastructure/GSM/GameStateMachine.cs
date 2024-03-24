using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.UI;
using Zenject;

namespace _Project.Scripts.Infrastructure.GSM
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, ISimpleState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }

    public class GameStateMachine : IGameStateMachine, IInitializable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(ISceneLoader sceneLoader, IGameFactory factory, ICurtainService curtain)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, factory, curtain),
                [typeof(GameLoopState)] = new GameLoopState()
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