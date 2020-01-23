using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesuviusData : MonoBehaviour
{
    public static string characterName = "Vesuvius";
    public static float characterSpeed = .15f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
        }
    }
}
