using UnityEngine;

namespace _Project.Scripts.Collectables
{
    public class Collectable : MonoBehaviour
    {
        public virtual void OnTriggerEnter(Collider other)
        {
            //TODO [PP 25/03/24]: Add coins to player
            Destroy(gameObject);
        }
    }
}