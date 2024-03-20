using UnityEngine;

namespace _Project.Scripts.Platforms
{
    public class PlatformMove : MonoBehaviour
    {
        public Transform Transform;
        public float Speed = 4;

        private void Update()
        {
            var distance = Speed * Time.deltaTime;
            Transform.localPosition += new Vector3(0, 0, -distance);
        }
    }
}