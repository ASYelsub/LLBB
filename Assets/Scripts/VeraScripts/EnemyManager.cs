using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager Enemies;
    public bool UseEnemyManager;
    public Vector3 MinSpawnValues, MaxSpawnValues;
    [Header("Unit Template to Spawn")]
    public GameObject EnemyPrefab;
    private static List<BaseUnit> ActiveEnemies = new List<BaseUnit>();

    private void Awake()
    {
        if(Enemies == null) { Enemies = this; } else { Destroy(this); }
        ActiveEnemies.Capacity = 4;
        BaseUnit.UnitDeath += OnUnitDeath;
        PrepareGeneration();
        if (UseEnemyManager) { GenerateEnemies(); }
    }

    public void GenerateEnemies()
    {
        PrepareGeneration();
        if (CanSpawnEnemies())
        {
            for (int i = 0; i < ActiveEnemies.Capacity; i++)
            {
                GameObject newEnemy = Instantiate(EnemyPrefab);
                newEnemy.transform.position = RandomSpawnPosition();
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
        Debug.Log(bu.name + " has been killed. " + ActiveEnemies.Count + " enemies remain.");
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

    Vector3 RandomSpawnPosition()
    {
        float x = UnityEngine.Random.Range(MinSpawnValues.x, MaxSpawnValues.x);
        float y = UnityEngine.Random.Range(MinSpawnValues.y, MaxSpawnValues.y);
        float z = UnityEngine.Random.Range(MinSpawnValues.z, MaxSpawnValues.z);
        return new Vector3(x,y,z);
    }

    #endregion
}


