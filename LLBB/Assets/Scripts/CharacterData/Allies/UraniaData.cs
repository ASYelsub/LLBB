using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniaData : MonoBehaviour
{
    public static string characterName = "Urania";
    public static float characterSpeed = .30f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
            Debug.Log("Enter has been pressed");
        }
    }
}
