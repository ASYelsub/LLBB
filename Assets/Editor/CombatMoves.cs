using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CombatMoves 
{
    #region Combat Move Constructors
    private static CombatMove NullCombatMove { get => new CombatMove(); }
    #endregion

    #region Combat Move Dictionary Lookup
    private static Dictionary<CombatMoveType, CombatMove> CombatMoveByType { get => new Dictionary<CombatMoveType, CombatMove>
    {
        {NullCombatMove.CombatMoveType, NullCombatMove}
    };
    }
    private static Dictionary<string, CombatMove> CombatMoveByString { get => new Dictionary<string, CombatMove>
    {
        { NullCombatMove.MoveName, NullCombatMove}
    };
    }
    #endregion

    public static CombatMove GetMoveByType(this CombatMoveType type) { if (CombatMoveByType.ContainsKey(type)) { return CombatMoveByType[type]; } return CombatMoveByType[CombatMoveType.EXAMPLE]; }
    public static CombatMove GetMoveByInt(int i) { return GetMoveByType((CombatMoveType)i); }
    public static CombatMove GetMoveByString(string s) { if (CombatMoveByString.ContainsKey(s)) { return CombatMoveByString[s]; } return CombatMoveByString["Example Move"]; }

    public static bool CanExecuteCombatMove(this BaseUnit b, CombatMove cm) { return b.SufficientStamina(cm.StaminaRequired); }
}

public enum CombatMoveType
{
    EXAMPLE = 0
}

[Serializable]
public class CombatMove
{
    public string MoveName;
    public CombatMoveType CombatMoveType;
    public float StaminaRequired;

    public CombatMove() { CombatMoveType = CombatMoveType.EXAMPLE; StaminaRequired = 0; MoveName = "Example Move"; }

    public virtual float DamageCalculationOutput(BaseUnit attacker, BaseUnit target)
    {
        return attacker.UnitStats[StatType.WHAMITUDE] - target.UnitStats[StatType.SKINTHICKNESS] / 2;
    }
}

