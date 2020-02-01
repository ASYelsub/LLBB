using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager Enemies;

    [Header("Unit Template to Spawn")]
    public GameObject EnemyPrefab;
    private static List<BaseUnit> ActiveEnemies = new List<BaseUnit>();

    private void Awake()
    {
        if(Enemies == null) { Enemies = this; } else { Destroy(this); }
        ActiveEnemies.Capacity = 4;
        BaseUnit.UnitDeath += OnUnitDeath;
        PrepareGeneration();
    }

    public void GenerateEnemies()
    {
        PrepareGeneration();
        if (CanSpawnEnemies())
        {
            for (int i = 0; i < ActiveEnemies.Capacity; i++)
            {
                GameObject newEnemy = Instantiate(EnemyPrefab);
                newEnemy.name = "Enemy #" + (i + 1).ToString();
                ActiveEnemies.Add(newEnemy.GetComponent<BaseUnit>());
                ActiveEnemies[i].GenerateUnitStats();
            }
        }
    }

    void OnUnitDeath(BaseUnit bu)
    {
        if (!ActiveEnemies.Contains(bu)) { return; }
        ActiveEnemies.Remove(bu);
        bu.OnDeath();
        if (ActiveEnemies.Count <= 0) { GenerateEnemies(); }
    }

    private void OnDestroy()
    {
        BaseUnit.UnitDeath -= OnUnitDeath;
    }

    #region HelperFunctions
    static bool CanSpawnEnemies()
    {
        if(ActiveEnemies == null) { return false; }
        return ActiveEnemies.Count == 0;
    }
    public void PrepareGeneration() { if (ActiveEnemies == null) { ActiveEnemies = new List<BaseUnit>(); } else { DestroyAllEnemies(Application.isEditor); } ActiveEnemies.Capacity = 4; }
    public void DestroyAllEnemies(bool inEditor = false)
    {
        if (inEditor)
        {
            for (int i = 0; i < ActiveEnemies.Count; i++) { DestroyImmediate(ActiveEnemies[i].gameObject); }
        } else
        {
            for (int j = 0; j < ActiveEnemies.Count; j++) { Destroy(ActiveEnemies[j].gameObject); }
        }
        ActiveEnemies.Clear();
    }

    public List<BaseUnit> GetActiveEnemies() { return ActiveEnemies; }

    #endregion
}

[CustomEditor(typeof(EnemyManager))]
public class EnemyManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EnemyManager e = (EnemyManager) target;
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
