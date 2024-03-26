using UnityEngine;

namespace _Project.Scripts.Collectables
{
    /// <summary>
    /// Simple collectable. OnTriggerEnter with the hero it implements its effect. 
    /// </summary>
    public class Collectable : MonoBehaviour
    {
        public virtual void OnTriggerEnter(Collider other)
        {
            //TODO [PP 25/03/24]: Add coins to player
            Destroy(gameObject);
        }
    }
}