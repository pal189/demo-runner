namespace _Project.Scripts.Infrastructure.GSM
{
    public interface IState
    {
        void Exit();
    }

    public interface ISimpleState : IState
    {
        void Enter();
    }
    
    public interface IPayloadedState<T> : IState
    {
        void Enter(T payload);
    }
}