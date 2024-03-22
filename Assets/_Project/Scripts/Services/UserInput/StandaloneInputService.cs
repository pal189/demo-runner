// using Lean.Touch;
// using UnityEngine;
//
// namespace _Project.Scripts.Services.UserInput
// {
//     public class StandaloneInputService : IInputService
//     {
//         private LeanFingerSwipe _leanFingerSwipe;
//
//         public StandaloneInputService(LeanFingerSwipe leanFingerSwipe)
//         {
//             _leanFingerSwipe = leanFingerSwipe;
//         }
//
//         public void OnSwipeLeft()
//         {
//             _leanFingerSwipe.OnDelta.
//         }
//
//         public override Vector2 Axis
//         {
//             get
//             {
//                 var axis = SimpleInputAxis();
//                 if (axis == Vector2.zero)
//                     axis = UnityAxis();
//
//                 return axis;
//             }
//         }
//
//         private Vector2 UnityAxis() =>
//             new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
//     }
// }