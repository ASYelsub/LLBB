using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CombatMoves 
{
    #region Combat Move Constructors
    private static CombatMove NullCombatMove { get => new CombatMove(); }
    private static Kick Kick { get => new Kick(); }
    #endregion

    #region Combat Move Dictionary Lookup
    private static Dictionary<CombatMoveType, CombatMove> CombatMoveByType { get => new Dictionary<CombatMoveType, CombatMove>
    {
        {NullCombatMove.CombatMoveType, NullCombatMove},
        { Kick.CombatMoveType, Kick}
    };
    }
    private static Dictionary<string, CombatMove> CombatMoveByString { get => new Dictionary<string, CombatMove>
    {
        { NullCombatMove.MoveName, NullCombatMove},
        { Kick.MoveName, Kick}
    };
    }
    #endregion

    public static CombatMove GetMoveByType(this CombatMoveType type) { if (CombatMoveByType.ContainsKey(type)) { return CombatMoveByType[type]; } return CombatMoveByType[CombatMoveType.EXAMPLE]; }
    public static CombatMove GetMoveByInt(int i) { return GetMoveByType((CombatMoveType)i); }
    public static CombatMove GetMoveByString(string s) { if (CombatMoveByString.ContainsKey(s)) { return CombatMoveByString[s]; } return CombatMoveByString["Example Move"]; }

    public static bool CanExecuteCombatMove(this BaseUnit b, CombatMove cm) { return b.SufficientStamina(cm.StaminaRequired); }

    public static float IdealDistanceFactor(this BaseUnit attacker, BaseUnit target)
    {
        float ideal = attacker.UnitType.IdealDistance; float actual = Mathf.Floor(Mathf.Abs(Vector3.Distance(attacker.transform.position, target.transform.position)));
        return Mathf.Min(1f, actual / ideal);
    }

}

public enum CombatMoveType
{
    EXAMPLE = 0, KICK = 1
        //to add another thing class that inherits from CombatMoveType, ad a comma and then be like PUNCH = 2, then, look down to see the class down below
}

[Serializable]
public class CombatMove
{
    public string MoveName;
    public CombatMoveType CombatMoveType;
    public float StaminaRequired, CoolDown;

    public CombatMove() { CombatMoveType = CombatMoveType.EXAMPLE; StaminaRequired = 0; CoolDown = 3; MoveName = "Example Move"; }

    public virtual float DamageCalculationOutput(BaseUnit attacker, BaseUnit target)
    {
        return attacker.UnitStats[StatType.WHAMITUDE] - target.UnitStats[StatType.SKINTHICKNESS] / 2; //this is the calculation for how much damage it does, can put in own custom
                                                                                                                                                                                    //formula for how the damage is calculated for any specific move                                                                            
    }
}

public class Kick : CombatMove
{
    public Kick() { CombatMoveType = CombatMoveType.KICK; StaminaRequired = 1; CoolDown = 5; MoveName = "Kick"; } //this overrides the CombatMove thing on line 45 for specifically KICK
    public override float DamageCalculationOutput(BaseUnit attacker, BaseUnit target)
    {
        return 0;
    }
}

