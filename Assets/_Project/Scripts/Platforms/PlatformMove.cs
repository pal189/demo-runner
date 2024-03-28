using _Project.Scripts.Level;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Platforms
{
    /// <summary>
    /// Makes the platform move.
    /// 
    public class PlatformMove : MonoBehaviour
    {
        public Transform Transform;
        private float Speed => _level.CurrentSpeed;
        private ILevel _level;

        [Inject]
        private void Construct(ILevel level)
        {
            _level = level;
        }

        private void Update()
        {
            var distance = Speed * Time.deltaTime;
            Transform.localPosition += new Vector3(0, 0, -distance);
        }
    }
}