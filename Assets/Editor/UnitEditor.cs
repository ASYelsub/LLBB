using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(BaseUnit))]
public class UnitEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BaseUnit b = (BaseUnit)target;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Unit Stats"))
        {
            b.GenerateUnitStats();
        }
        if (GUILayout.Button("Set as Focus Unit for Moveset"))
        {
            MoveButtonManager.SetFocusUnit(b);
        }


        GUILayout.EndHorizontal();


        if (b.UnitStats != null)
        {
            GUILayout.Label("Current Unit Max Stats:", EditorStyles.boldLabel);
            for (int i = 0; i < b.UnitStats.Count; i++)
            {
                GUILayout.Label(b.UnitStats.ElementAt(i).Key.ToString() + ": " + b.UnitStats.ElementAt(i).Value.ToString());
            }
        }

        if (b.UnitCombatMoves != null)
        {
            GUILayout.Label("Unit Attacks: ", EditorStyles.boldLabel);
            for (int j = 0; j < b.UnitCombatMoves.Count; j++)
            {
                GUILayout.Label(b.UnitCombatMoves[j].GetMoveByType().MoveName + ": " + b.UnitCombatMoves[j].GetMoveByType().StaminaRequired.ToString() + " Stamina Required");
            }
        }
    }
}

