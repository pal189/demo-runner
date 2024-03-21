using UnityEngine;

namespace _Project.Scripts.Services
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}