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

    public virtual bool GenerateRandomStats { get => true; }

    public List<CombatMoveType> UnitCombatMoves;

    public static event Action<BaseUnit> UnitDeath;
    public static event Action<BaseUnit, float> UnitAttacked;

    public BaseUnit TargetToEffect;

    public virtual void Start()
    {
        if (GenerateRandomStats) { GenerateUnitStats(); }
        UnitAttacked += TakeDamageFromAttack;
    } 

    private void Update()
    {
        if (UnitKilled())
        {
            BroadcastUnitDeath();
           //OnDeath();
        }
    }

    public void SetTargetToEffect(BaseUnit b)
    {
        TargetToEffect = b;
    }

    public void BroadcastUnitAttacked(CombatMoveType moveUsed)
    {
        Debug.Log(name + " used: " + moveUsed);
        if(TargetToEffect != null)
        {
            if (UnitAttacked != null)
            {
                var combat = moveUsed.GetMoveByType();
                if (SufficientStamina(combat.StaminaRequired)) { UnitAttacked(TargetToEffect, combat.DamageCalculationOutput(this, TargetToEffect)); }
                CurrentStamina.CurrentValue -= combat.StaminaRequired;
            }
        }
    }

    void TakeDamageFromAttack(BaseUnit t, float dmg)
    {
        if (t == this)
        {
            CurrentHP.CurrentValue -= dmg;
        }
    }

    public BaseClass[] GetBaseClasses() { return Resources.LoadAll<BaseClass>("Class Scriptables"); }

    public BaseClass GetBaseClass(string className) { return Resources.Load<BaseClass>("Class Scriptables/" + className + ".asset"); }

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

    public void BroadcastUnitDeath()
    {
        if (UnitDeath!=null) { UnitDeath(this); }
    }

    private void OnDestroy()
    {
        UnitAttacked -= TakeDamageFromAttack;
    }
}
