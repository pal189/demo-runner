namespace _Project.Scripts._Core.GSM
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