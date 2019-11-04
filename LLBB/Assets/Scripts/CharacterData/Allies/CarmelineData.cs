using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmelineData : MonoBehaviour
{
    public static string characterName = "Carmeline";
    public static float characterSpeed = .20f;
    public ActiveCharMovement activeCharMovement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            activeCharMovement.getCharacterSpeed(characterName,characterSpeed);
        }
    }
}
