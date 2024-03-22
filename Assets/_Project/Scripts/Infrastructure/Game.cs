using _Project.Scripts.Infrastructure;
using _Project.Scripts.Services;
using DG.Tweening;
using UnityEngine;

public class Game
{
    public static Factory Factory;
    public static IInputService InputService;

    public Game()
    {
        InitDOTween();
        RegisterFactory();
        RegisterInputService();
    }

    private void InitDOTween()
    {
        DOTween.Init(true, false, LogBehaviour.Verbose);
    }

    private void RegisterInputService()
    {
        if(Application.isEditor)
            InputService = new StandaloneInputService();
        else
            InputService = new MobileInputService();
    }

    private static void RegisterFactory() => Factory = new Factory();
}