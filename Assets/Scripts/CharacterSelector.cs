using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public ActiveCharMovement activeCharMovement;
    //Intent: select active character GameObject
    public Button characterSelectOne,characterSelectTwo,characterSelectThree,characterSelectFour;
    public GameObject activeCharacter;
    

    public void SelectCharacter(Button selectCharacter){
        Debug.Log("Button Pressed");
        if(selectCharacter == characterSelectOne){
            Debug.Log("Character1");
            activeCharMovement.setActiveCharacter(1);
        }
        else if(selectCharacter == characterSelectTwo){
            Debug.Log("Character2");
            activeCharMovement.setActiveCharacter(2);
        }
        else if(selectCharacter == characterSelectThree){
            Debug.Log("Character3");
            activeCharMovement.setActiveCharacter(3);
        }
        else if(selectCharacter == characterSelectFour){
            Debug.Log("Character4");
            activeCharMovement.setActiveCharacter(4);
        }
    }

}
