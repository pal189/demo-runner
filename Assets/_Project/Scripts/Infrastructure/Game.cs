using _Project.Scripts.Infrastructure;
using _Project.Scripts.Services;
using UnityEngine;

public class Game
{
    public static Factory Factory;
    public static IInputService InputService;

    public Game()
    {
        RegisterFactory();
        RegisterInputService();
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