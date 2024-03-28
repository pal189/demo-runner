using UnityEngine;

namespace _Project.Scripts.Collectables
{
    /// <summary>
    /// Can be collected by the player. OnTriggerEnter with the hero it is destroed and (to be implemented) adds coins to the player 
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