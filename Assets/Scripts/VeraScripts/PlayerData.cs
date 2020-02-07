using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Combat/CustomCharacter")]
public class PlayerData : ScriptableObject
{
    public string CharacterName;
    public BaseClass PlayerUnitClass;

    public List<CombatMoveType> CharacterSpecificMoves;
}
