using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbyData : MonoBehaviour
{
    public static string characterName = "Bobby";
    public static float characterSpeed = .05f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
        }
    }
}
