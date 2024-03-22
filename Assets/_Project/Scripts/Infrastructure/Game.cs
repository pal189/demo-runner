using _Project.Scripts.Infrastructure;
using _Project.Scripts.Services.UserInput;
using DG.Tweening;

public class Game
{
    public static Factory Factory;
    public static IInputService InputService;

    public Game(InputCreator inputCreator)
    {
        InitDOTween();
        RegisterFactory();
        RegisterInputService(inputCreator);
    }

    private void InitDOTween()
    {
        DOTween.Init(true, false, LogBehaviour.Verbose);
    }

    private void RegisterInputService(InputCreator inputCreator)
    {
        InputService = inputCreator.CreateInputService();
    }

    private void RegisterFactory() => Factory = new Factory();
}