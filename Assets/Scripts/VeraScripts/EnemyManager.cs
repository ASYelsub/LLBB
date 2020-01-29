using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void GenerateEnemies()
    {
        for (int i = 0; i < ActiveEnemies.Capacity; i++)
        {
            GameObject newEnemy = Instantiate(EnemyPrefab);
            try
            {
                ActiveEnemies.Add(newEnemy.GetComponent<BaseUnit>());
            }
            catch (NullReferenceException) { }
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

}
