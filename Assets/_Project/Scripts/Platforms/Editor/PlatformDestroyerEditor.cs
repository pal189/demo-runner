using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Platforms.Editor
{
    /// <summary>
    /// Editor for the platform destroyer. Draws a red sphere in the editor for quick find in the scene.
    /// 
    [CustomEditor(typeof(PlatformDestroyer))]
    public class PlatformDestroyerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlatformDestroyer destroyer, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(destroyer.transform.position, 0.5f);
        }
    }
}