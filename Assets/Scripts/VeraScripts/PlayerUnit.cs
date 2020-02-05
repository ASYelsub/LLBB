using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : BaseUnit
{
    public override bool GenerateRandomStats => false;
    public PlayerData PlayerUnitData;

    public override void Start()
    {
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
    }
}
