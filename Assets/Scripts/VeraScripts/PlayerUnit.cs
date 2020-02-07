using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : BaseUnit
{
    
    public PlayerData PlayerUnitData;

    public override void Start()
    {
        GenerateRandomStats = false;
        base.Start();
    }
    
    public void SetPlayerStats(PlayerData p)
    {
        PlayerUnitData = p;
        SetPlayerStats();
    }

    public void SetPlayerStats()
    {
        UnitStats = new Dictionary<StatType, float>();
        UnitType = PlayerUnitData.PlayerUnitClass;
        if (UnitType != null && UnitType.ClassStatSettings.Length > 0)
        {
            UnitType.GenerateStats(this);
        }
        CurrentHP = new CombatStat(StatType.HEALTH, this);
        CurrentStamina = new CombatStat(StatType.STAMINA, this);
    }
}
