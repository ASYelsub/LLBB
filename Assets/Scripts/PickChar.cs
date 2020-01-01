using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickChar : MonoBehaviour
{
    public CharacterStatStorage ourStatStorage;
    public Transform activeCharTransform;
    public Camera cam;
    public Text[] charText = new Text[4];
    int characterNumber = 0;
    string[] selectedCharacters = new string[4];
    public string[] charNames = new string[9];
    public Text activeName;
    bool hoverOverDragable = false;
    bool dragableHeld = false;
    Vector3 mousePos;
    Vector3 originalPos;
    int heldNumber = 0;
    public Text[] activeStat = new Text[9];
   
    public void Awake(){
        activeName.text = charNames[characterNumber];
        activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        originalPos = activeCharTransform.position;
        selectedCharacters[0] = "C1";
        selectedCharacters[1] = "C2";
        selectedCharacters[2] = "C3";
        selectedCharacters[3] = "C4";

    }
    
    public void Update(){
        //Debug.Log(characterNumber);
        mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,-1);
        if (dragableHeld == true){
            activeCharTransform.position = mousePos;}
        else if(dragableHeld == false || hoverOverDragable == false){
            activeCharTransform.position = originalPos;}
    }

//click "arrow buttons" to switch from character to character
public void ChangeActiveCharArray(int direction){ //0 = left, 1 = right
        if(direction == 1 && characterNumber < charNames.Length - 1){
            characterNumber++;
            activeName.text = charNames[characterNumber];
            activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        }
        else if(direction == 1 && characterNumber == charNames.Length - 1){
            characterNumber = 0;
            activeName.text = charNames[characterNumber];
            activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        }
        if(direction == 0 && characterNumber > 0){
            characterNumber --;
            activeName.text = charNames[characterNumber];
            activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        }
        else if(direction == 0 && characterNumber == 0){
            characterNumber = 8;
            activeName.text = charNames[characterNumber];
            activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        }
        
    }
    //this is set when the character presses the "left" or "right" button
    public void SaveActiveCharacters(){
        selectedCharacters[0] = charText[0].text;
        selectedCharacters[1] = charText[1].text;
        selectedCharacters[2] = charText[2].text;
        selectedCharacters[3] = charText[3].text;
    }
    

    //dragging and assigning "character" in 1,2,3,4 slots functions
    public void MouseHover(){
        hoverOverDragable = true;
    }
    public void MouseNotHover(){
        hoverOverDragable = false;
    }
    public void OnMouseDown(){
        dragableHeld = true;
    }
    public void OnMouseUp(){
     dragableHeld = false;
     SetChar();
    }
    public void OverChar(int i){
        if (dragableHeld == true){//Debug.Log("OverChar plus letGo");
            if (i == 1)
                { heldNumber = 1; }
            if (i == 2)
                { heldNumber = 2; }
            if (i == 3)
                { heldNumber = 3; }
            if (i == 4)
                { heldNumber = 4; }
            if (i == 0) //on exit from char buttons set i as 0
                { heldNumber = 0; }
        }
    }
    //setting who "character" is when let go
    void SetChar(){
        if (heldNumber == 1)
            { charText[0].text = activeName.text; 
              charText[1].text = selectedCharacters[1]; 
              charText[2].text = selectedCharacters[2]; 
              charText[3].text = selectedCharacters[3]; }
        if (heldNumber == 2)
            { charText[0].text = selectedCharacters[0]; 
              charText[1].text = activeName.text; 
              charText[2].text = selectedCharacters[2]; 
              charText[3].text = selectedCharacters[3]; }
        if (heldNumber == 3)
            { charText[0].text = selectedCharacters[0]; 
              charText[1].text = selectedCharacters[1]; 
              charText[2].text = activeName.text; 
              charText[3].text = selectedCharacters[3]; }
        if (heldNumber == 4)
            { charText[0].text = selectedCharacters[0]; 
              charText[1].text = selectedCharacters[1]; 
              charText[2].text = selectedCharacters[2]; 
              charText[3].text = activeName.text; }
    }

    

    //closing menu
    public void BeginGame(){
        //triggered by pressing start button
        this.gameObject.SetActive(false);
    }
}
