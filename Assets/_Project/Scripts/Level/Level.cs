using UnityEngine;
using Zenject;

namespace _Project.Scripts.Data
{
    public interface ILevel
    {
        int CurrentSpeed { get; set; }
    }

    public class Level : MonoBehaviour, ILevel, IInitializable
    {
        public int InitialSpeed;
        public int CurrentSpeed { get; set; }

        public void Initialize()
        {
            CurrentSpeed = InitialSpeed;
        }
    }
}