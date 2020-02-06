using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "Combat/Classes")]
public class BaseClass : ScriptableObject
{
    public CombatStatSetting[] ClassStatSettings;

    public void GenerateStats(BaseUnit u)
    {
        if (u.UnitStats == null || u.UnitStats.Count > 9) { return; }
        for (int i = 0; i < ClassStatSettings.Length; i++)
        {
            u.UnitStats.Add(ClassStatSettings[i].CombatStatType, ClassStatSettings[i].GenerateStat());
        }
    }
}

[System.Serializable]
public struct CombatStatSetting
{
	public StatType CombatStatType;
	public float StatMaxValue;
    public float StatBonus;

    public CombatStatSetting(StatType stat, float bonus, float max)
	{
		CombatStatType = stat;
		StatBonus = bonus;
		StatMaxValue = max;
	}

	public float GenerateStat(){ return Mathf.Ceil(Random.Range(5f, StatMaxValue)) + StatBonus;}
}

[System.Serializable]
public class CombatStat
{
    public StatType CombatStatType;
    public float CurrentValue;

    public CombatStat() { CombatStatType = StatType.NONE; CurrentValue = 1; }

    public CombatStat(StatType t, BaseUnit u)
    {
        CombatStatType = t;
        CurrentValue = u.UnitStats[t];
    }

    public void SetToMax(BaseUnit u)
    {
        CurrentValue = u.UnitStats[CombatStatType];
    }
}

public enum StatType
{
    NONE = 0,
    HEALTH = 1,
    STAMINA = 2,
    WHAMITUDE = 3,
    POPULARITY = 4,
    SCHOOLSPIRIT = 5,
    CREEPINESS = 6,
    SKINTHICKNESS = 7,
    INDEPENDENCE = 8,
    EMPATHY = 9,
    STRUT = 10
}

