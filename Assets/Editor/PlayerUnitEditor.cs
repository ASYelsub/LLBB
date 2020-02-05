using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerUnit))]
public class PlayerUnitEditor : UnitEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Set as Active Character"))
        {
            PlayerUnitManager.SetActivePlayerUnit((PlayerUnit)target);
        }
    }
}
