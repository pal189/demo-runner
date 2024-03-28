using UnityEngine;

namespace _Project.Scripts._Core.Misc
{
    /// <summary>
    /// Makes the game object DontDestroyOnLoad.
    /// </summary>
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}