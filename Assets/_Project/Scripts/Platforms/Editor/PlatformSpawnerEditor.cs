using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Platforms
{
    [CustomEditor(typeof(PlatformSpawner))]
    public class PlatformSpawnerEditor : Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlatformSpawner spawner, GizmoType gizmoType)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}

namespace _Project.Scripts.Platforms
{
}
