using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//USAGE: this lets you click on character bubbles during combat to change who you are playing as, works with buttons
public class CharacterSelector : MonoBehaviour
{
    //public MoveManager moveManager;
    public ActiveCharMovement activeCharMovement;
    //Intent: select active character GameObject
    public Button characterSelectOne,characterSelectTwo,characterSelectThree,characterSelectFour;
    public GameObject activeCharacter;

    public void BeginGame()
    {
        this.gameObject.SetActive(false);
    }

    public void SelectCharacter(Button selectCharacter){
        Debug.Log("Button Pressed");
        if(selectCharacter == characterSelectOne){
 //           Debug.Log("Character1");
            activeCharMovement.setActiveCharacter(1);
            //moveManager.DisplayActiveMoveset(1);
        }
        else if(selectCharacter == characterSelectTwo){
 //           Debug.Log("Character2");
            activeCharMovement.setActiveCharacter(2);
            //moveManager.DisplayActiveMoveset(2);
        }
        else if(selectCharacter == characterSelectThree){
//            Debug.Log("Character3");
            activeCharMovement.setActiveCharacter(3);
            //moveManager.DisplayActiveMoveset(3);
        }
        else if(selectCharacter == characterSelectFour){
//            Debug.Log("Character4");
            activeCharMovement.setActiveCharacter(4);
            //moveManager.DisplayActiveMoveset(4);
        }
    }
    //Create a custom button that stores the reference to the base unit on assigning 
    [System.Serializable]
    public struct CharacterSelectButton
    {
        public Button charButton;
        public BaseUnit thisUnit;
    }

}
