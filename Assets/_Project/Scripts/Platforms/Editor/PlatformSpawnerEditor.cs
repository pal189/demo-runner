using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Platforms.Editor
{
    /// <summary>
    /// Editor for the platform spawner. Draws a green sphere in the editor for quick find in the scene.
    /// 
    [CustomEditor(typeof(PlatformSpawner))]
    public class PlatformSpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlatformSpawner spawner, GizmoType gizmoType)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}