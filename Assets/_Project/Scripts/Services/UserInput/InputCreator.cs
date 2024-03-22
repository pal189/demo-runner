using Lean.Touch;
using UnityEngine;

namespace _Project.Scripts.Services.UserInput
{
    public class InputCreator : MonoBehaviour
    {
        [SerializeField] private LeanFingerSwipe _leanFingerSwipe; 
        public IInputService CreateInputService()
        {
            return new MobileInputService(_leanFingerSwipe);
            // if(Application.isEditor)
            //     return new StandaloneInputService(_leanFingerSwipe);
            // else
            //     return new MobileInputService(_leanFingerSwipe);
        }
    }
}