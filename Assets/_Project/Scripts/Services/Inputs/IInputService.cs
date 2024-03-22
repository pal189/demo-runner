using UniRx;

namespace _Project.Scripts.Services.Inputs
{
    public interface IInputService
    {
        ReactiveCommand OnSwipeLeft { get; }
        ReactiveCommand OnSwipeRight { get; }
    }
}