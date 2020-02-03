using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(EnemyManager))]
public class EnemyManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EnemyManager e = (EnemyManager)target;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Wave of Enemies"))
        {
            e.GenerateEnemies();
        }
        if (GUILayout.Button("Destroy All Enemies"))
        {
            e.DestroyAllEnemies(Application.isEditor);
        }
        GUILayout.EndHorizontal();

        foreach (var a in e.GetActiveEnemies())
        {
            GUILayout.Label(a.name + ": " + a.UnitType.ToString());
        }
    }
}