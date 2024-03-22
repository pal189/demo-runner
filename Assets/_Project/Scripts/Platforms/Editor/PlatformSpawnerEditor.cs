using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Platforms.Editor
{
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