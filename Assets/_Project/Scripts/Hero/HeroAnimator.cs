using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private static readonly int isMoving = Animator.StringToHash("IsMoving");
    private static readonly int isJumping = Animator.StringToHash("IsJumping");
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
    }

    public void StopJumping() => Animator.SetBool(isJumping, false);
}
