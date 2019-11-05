using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeData : MonoBehaviour
{
    string characterName = "Rake";
    float characterSpeed = .05f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
        }
    }
}
