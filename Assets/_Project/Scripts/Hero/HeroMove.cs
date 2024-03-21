using UnityEngine;

namespace _Project.Scripts.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour
    {
        public HeroAnimator HeroAnimator;
        private void Awake()
        {
            HeroAnimator.Move(0.3f);
        }
    }
}