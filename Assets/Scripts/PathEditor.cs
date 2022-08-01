using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Path))]
public class PathEditor : UnityEditor.Editor
{
    public static void DrawGizmo(Path path)
    {
        foreach (var node in path.Nodes)
        {
            Gizmos.DrawSphere(node.pos, 0.1f);
        }
    }
    private void OnSceneGUI()
    {
        var path = target as Path;
           
        foreach (var node in path.Nodes)
        {
            //adding handles to nodes, so they can be moved 
            node.pos = Handles.DoPositionHandle(node.pos, Quaternion.identity);
        }
    }
}
