using UnityEngine;

namespace _Project.Scripts.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour
    {
        public HeroAnimator HeroAnimator;
        public CharacterController CharacterController;

        private void Awake()
        {
            HeroAnimator.Move(0.7f);
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            movementVector += Physics.gravity;

            
            // CharacterController.isGroundeddo(movementVector * Time.deltaTime);
        }
    }
}