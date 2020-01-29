using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class BaseUnit : MonoBehaviour
{
	public BaseClass UnitType;
	public Dictionary<StatType, float> UnitStats;

    public CombatStat CurrentHP;
    public CombatStat CurrentStamina;

    public static event Action<BaseUnit> UnitDeath;

    void Start()
    {
        //GenerateUnitStats();
    }

    private void Update()
    {
        if (UnitKilled())
        {
            BroadcastUnitDeath();
        }
    }

    public void OnDeath()
    {
        Debug.Log("Unit has died. Now destroying " + name);
        Destroy(gameObject);
    }

    public void DebugStats(){
        Debug.Log(this.name);
		for(int i = 0;i< UnitStats.Count; i++){
			Debug.Log(UnitStats.ElementAt(i).Key + ": " + UnitStats.ElementAt(i).Value);
		}
	}

    public void GenerateUnitStats()
    {
        UnitStats = new Dictionary<StatType, float>();
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
            b.DebugStats();
        }
    }
}
