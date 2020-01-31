using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using Random = UnityEngine.Random;

public class BaseUnit : MonoBehaviour
{
	public BaseClass UnitType;
	public Dictionary<StatType, float> UnitStats;

    public CombatStat CurrentHP;
    public CombatStat CurrentStamina;

    public static event Action<BaseUnit> UnitDeath;

    private void Start()
    {
        GenerateUnitStats();
    }

    private void Update()
    {
        if (UnitKilled())
        {
            BroadcastUnitDeath();
        }
    }

    public BaseClass[] GetBaseClasses() { return Resources.LoadAll<BaseClass>("Classes"); }

    public BaseClass GetBaseClass(string className) { return Resources.Load<BaseClass>("Classes/" + className + ".asset"); }

    public BaseClass GetBaseClass(int index) { if (index < GetBaseClasses().Length) { return GetBaseClasses()[index]; } return null; }

    public BaseClass GetBaseClass() { if (GetBaseClasses().Length <= 0) { return null; } return GetBaseClasses()[Mathf.FloorToInt(Random.Range(0, GetBaseClasses().Length))]; }

    public void OnDeath()
    {
        Debug.Log("Unit has died. Now destroying " + name);
        Destroy(gameObject);
    }

    public void GenerateUnitStats()
    {
        UnitStats = new Dictionary<StatType, float>();
        UnitType = GetBaseClass();
        if (UnitType != null && UnitType.ClassStatSettings.Length > 0)
        {
            UnitType.GenerateStats(this);
        }

        CurrentHP = new CombatStat(StatType.HEALTH, this);
        CurrentStamina = new CombatStat(StatType.STAMINA, this);
    }

    public bool UnitKilled()
    {
        return CurrentHP.CurrentValue <= 0;
    }

    public bool SufficientStamina(float amountNeeded)
    {
        return CurrentStamina.CurrentValue >= amountNeeded;
    }

    void BroadcastUnitDeath()
    {
        if (UnitDeath!=null) { UnitDeath(this); }
    }

}
[CustomEditor(typeof(BaseUnit))]
public class UnitEditor: Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BaseUnit b = (BaseUnit)target;
        if (GUILayout.Button("Generate Unit Stats"))
        {
            b.GenerateUnitStats();
        }

        if (b.UnitStats != null)
        {
            GUILayout.Label("Current Unit Max Stats:");
            for (int i = 0; i < b.UnitStats.Count; i++)
            {
                GUILayout.Label(b.UnitStats.ElementAt(i).Key.ToString() + ": " + b.UnitStats.ElementAt(i).Value.ToString());
            }
        }

    }
}
