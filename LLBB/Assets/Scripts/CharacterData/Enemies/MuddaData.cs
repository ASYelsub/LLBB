using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuddaData : MonoBehaviour
{
    string characterName = "Mudda";
    float characterSpeed = .05f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
        }
    }
}
