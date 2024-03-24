using UnityEngine;

namespace _Project.Scripts.Collectables
{
    public class Collectable : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}