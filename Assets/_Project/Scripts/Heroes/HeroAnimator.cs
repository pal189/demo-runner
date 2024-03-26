using UnityEngine;

namespace _Project.Scripts.Heroes
{
    /// <summary>
    /// The class that controlls the Animator of the hero by changing Animator's parameters. 
    /// </summary>
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int isMoving = Animator.StringToHash("IsMoving");
        private static readonly int isJumping = Animator.StringToHash("IsJumping");
        private static readonly int isFalling = Animator.StringToHash("IsFalling");
        private static readonly int isMidAir = Animator.StringToHash("IsMidAir");
        private static readonly int Speed = Animator.StringToHash("Speed");

        public Animator Animator;

        public void Move(float speed)
        {
            Animator.SetBool(isMoving, true);
            Animator.SetFloat(Speed, speed);
        }
    
        public void StopMoving() => 
            Animator.SetBool(isMoving, false);
    
        public void Jump()
        {
            StopMoving();
            Animator.SetBool(isJumping, true);
            Animator.SetBool(isMidAir, false);
            Animator.SetBool(isFalling, false);
        }
        
        public void Fall()
        {
            StopMoving();
            Animator.SetBool(isJumping, false);
            Animator.SetBool(isMidAir, false);
            Animator.SetBool(isFalling, true);
        }
        
        public void MidAir()
        {
            Animator.SetBool(isJumping, false);
            Animator.SetBool(isMidAir, true);
            Animator.SetBool(isFalling, false);
        }
        
        public void StopJumping()
        {
            Animator.SetBool(isJumping, false);
            Animator.SetBool(isMidAir, false);
            Animator.SetBool(isFalling, false);
        }

    }
}
