using _Project.Scripts.Services.UserInput;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public InputCreator InputCreator;
    private Game _game;

    private void Awake()
    {
        _game = new Game(InputCreator);
        DontDestroyOnLoad(this);
    }
}