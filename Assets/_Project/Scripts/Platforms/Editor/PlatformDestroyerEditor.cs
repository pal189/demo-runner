using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Platforms
{
    [CustomEditor(typeof(PlatformDestroyer))]
    public class PlatformDestroyerEditor : Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlatformDestroyer destroyer, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(destroyer.transform.position, 0.5f);
        }
    }
}