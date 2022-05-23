using Platformer.Game.Enemy;
using UnityEditor;
using UnityEngine;

namespace Platformer.Game.Editor
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawGizmo(EnemySpawner component, GizmoType gizmoType)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(component.transform.position, .3f);
        }
    }
}