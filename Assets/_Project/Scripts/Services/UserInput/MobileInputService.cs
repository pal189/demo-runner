using Lean.Touch;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Services.UserInput
{
    public class MobileInputService : IInputService
    {
        private LeanFingerSwipe _leanFingerSwipe;

        public MobileInputService(LeanFingerSwipe leanFingerSwipe)
        {
            _leanFingerSwipe = leanFingerSwipe;
            _leanFingerSwipe.OnDelta.AddListener(OnSwipe);
        }

        private void OnSwipe(Vector2 arg0)
        {
            Debug.Log(arg0);
        }
    }
}