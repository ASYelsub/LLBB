using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesuviusData : MonoBehaviour
{
    string characterName = "Vesuvius";
    float characterSpeed = .15f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
        }
    }
}
