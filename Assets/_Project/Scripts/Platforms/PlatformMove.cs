using _Project.Scripts.Data;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Platforms
{
    public class PlatformMove : MonoBehaviour
    {
        public Transform Transform;
        private float Speed => _level.CurrentSpeed;
        private ILevel _level;

        [Inject]
        public void Construct(ILevel level)
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