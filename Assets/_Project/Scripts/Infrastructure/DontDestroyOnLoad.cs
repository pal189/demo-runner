using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}