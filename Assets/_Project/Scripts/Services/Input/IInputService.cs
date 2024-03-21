using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Services
{
    public interface IInputService
    {
        Vector2 Axis { get; }
    }
}