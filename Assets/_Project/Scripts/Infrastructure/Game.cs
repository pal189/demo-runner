using _Project.Scripts.Infrastructure;

public class Game
{
    public static Factory Factory;

    public Game()
    {
        RegisterFactory();
    }

    private static void RegisterFactory() => Factory = new Factory();
}