using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public Button characterSelectOne,characterSelectTwo,characterSelectThree,characterSelectFour;

    public void SelectCharacter(Button selectCharacter){
        if(selectCharacter == characterSelectOne){
            Debug.Log("Character1");
        }
        else if(selectCharacter == characterSelectTwo){
            Debug.Log("Character2");
        }
        else if(selectCharacter == characterSelectThree){
            Debug.Log("Character3");
        }
        else if(selectCharacter == characterSelectFour){
            Debug.Log("Character4");
        }
    }

}
