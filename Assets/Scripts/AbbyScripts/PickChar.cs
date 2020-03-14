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
    public Sprite[] charSprites = new Sprite[9];
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
    public GameObject[] infoBoxes = new GameObject[9];
    public Image characterPicture;
    public GameObject movesHolder;
    public bool onChar = false;

    public int currentMenu; //0 = stats, 1 = skills, 2 = gear
    public Text menuName;
    public string[] menuNames = new string[3]; //0 = stats, 1 = skills, 2 = gear

    public GameObject statDisplay, movesDisplay, gearDisplay;

   
    public void Awake(){
        menuNames[0] = "Stats";
        menuNames[1] = "Skills";
        menuNames[2] = "Gear";
        activeName.text = charNames[characterNumber];
        activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        characterPicture.sprite = charSprites[characterNumber];
        originalPos = activeCharTransform.position;
        selectedCharacters[0] = "C1";
        selectedCharacters[1] = "C2";
        selectedCharacters[2] = "C3";
        selectedCharacters[3] = "C4";
            activeStat[characterNumber].text = ourStatStorage.health[characterNumber].ToString();
            activeStat[1].text = ourStatStorage.stamina[characterNumber].ToString();
            activeStat[2].text = ourStatStorage.whamitude[characterNumber].ToString();
            activeStat[3].text = ourStatStorage.popularity[characterNumber].ToString();
            activeStat[4].text = ourStatStorage.schoolSpirit[characterNumber].ToString();
            activeStat[5].text = ourStatStorage.creepiness[characterNumber].ToString();
            activeStat[6].text = ourStatStorage.skinThickness[characterNumber].ToString();
            activeStat[7].text = ourStatStorage.independence[characterNumber].ToString();
            activeStat[8].text = ourStatStorage.empathy[characterNumber].ToString();
            activeStat[9].text = ourStatStorage.strut[characterNumber].ToString();
        infoBoxes[0].SetActive(false);
        infoBoxes[1].SetActive(false);
        infoBoxes[2].SetActive(false);
        infoBoxes[3].SetActive(false);
        infoBoxes[4].SetActive(false);
        infoBoxes[5].SetActive(false);
        infoBoxes[6].SetActive(false);
        infoBoxes[7].SetActive(false);
        infoBoxes[8].SetActive(false);
        infoBoxes[9].SetActive(false);
        movesHolder.SetActive(false);
        currentMenu = 0;
    }
    
    public void Update(){
        //Debug.Log(characterNumber);
        //activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
        //Debug.Log(ourStatStorage.health[characterNumber].ToString());
        //Debug.Log(heldNumber);
        mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,-1);
        if (dragableHeld == true){
            activeCharTransform.position = mousePos;}
        else if(dragableHeld == false || hoverOverDragable == false){
            activeCharTransform.position = originalPos;}
    }

//click "arrow buttons" to switch from character to character
public void ChangeActiveCharArray(int direction){ //0 = left, 1 = right
        heldNumber = 0;
        if(direction == 1 && characterNumber < charNames.Length - 1){
            characterNumber++;
            characterPicture.sprite = charSprites[characterNumber];
            activeName.text = charNames[characterNumber];
                activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
                activeStat[1].text = ourStatStorage.stamina[characterNumber].ToString();
                activeStat[2].text = ourStatStorage.whamitude[characterNumber].ToString();
                activeStat[3].text = ourStatStorage.popularity[characterNumber].ToString();
                activeStat[4].text = ourStatStorage.schoolSpirit[characterNumber].ToString();
                activeStat[5].text = ourStatStorage.creepiness[characterNumber].ToString();
                activeStat[6].text = ourStatStorage.skinThickness[characterNumber].ToString();
                activeStat[7].text = ourStatStorage.independence[characterNumber].ToString();
                activeStat[8].text = ourStatStorage.empathy[characterNumber].ToString();
                activeStat[9].text = ourStatStorage.strut[characterNumber].ToString();
        }
        else if(direction == 1 && characterNumber == charNames.Length - 1){
            characterNumber = 0;
            characterPicture.sprite = charSprites[characterNumber];
            activeName.text = charNames[characterNumber];
                activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
                activeStat[1].text = ourStatStorage.stamina[characterNumber].ToString();
                activeStat[2].text = ourStatStorage.whamitude[characterNumber].ToString();
                activeStat[3].text = ourStatStorage.popularity[characterNumber].ToString();
                activeStat[4].text = ourStatStorage.schoolSpirit[characterNumber].ToString();
                activeStat[5].text = ourStatStorage.creepiness[characterNumber].ToString();
                activeStat[6].text = ourStatStorage.skinThickness[characterNumber].ToString();
                activeStat[7].text = ourStatStorage.independence[characterNumber].ToString();
                activeStat[8].text = ourStatStorage.empathy[characterNumber].ToString();
                activeStat[9].text = ourStatStorage.strut[characterNumber].ToString();
        }
        if(direction == 0 && characterNumber > 0){
            characterNumber --;
            characterPicture.sprite = charSprites[characterNumber];
            activeName.text = charNames[characterNumber];
                activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
                activeStat[1].text = ourStatStorage.stamina[characterNumber].ToString();
                activeStat[2].text = ourStatStorage.whamitude[characterNumber].ToString();
                activeStat[3].text = ourStatStorage.popularity[characterNumber].ToString();
                activeStat[4].text = ourStatStorage.schoolSpirit[characterNumber].ToString();
                activeStat[5].text = ourStatStorage.creepiness[characterNumber].ToString();
                activeStat[6].text = ourStatStorage.skinThickness[characterNumber].ToString();
                activeStat[7].text = ourStatStorage.independence[characterNumber].ToString();
                activeStat[8].text = ourStatStorage.empathy[characterNumber].ToString();
                activeStat[9].text = ourStatStorage.strut[characterNumber].ToString();
        }
        else if(direction == 0 && characterNumber == 0){
            characterNumber = 8;
            characterPicture.sprite = charSprites[characterNumber];
            activeName.text = charNames[characterNumber];
                activeStat[0].text = ourStatStorage.health[characterNumber].ToString();
                activeStat[1].text = ourStatStorage.stamina[characterNumber].ToString();
                activeStat[2].text = ourStatStorage.whamitude[characterNumber].ToString();
                activeStat[3].text = ourStatStorage.popularity[characterNumber].ToString();
                activeStat[4].text = ourStatStorage.schoolSpirit[characterNumber].ToString();
                activeStat[5].text = ourStatStorage.creepiness[characterNumber].ToString();
                activeStat[6].text = ourStatStorage.skinThickness[characterNumber].ToString();
                activeStat[7].text = ourStatStorage.independence[characterNumber].ToString();
                activeStat[8].text = ourStatStorage.empathy[characterNumber].ToString();
                activeStat[9].text = ourStatStorage.strut[characterNumber].ToString();
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
                { heldNumber = 1;}
            if (i == 2)
                { heldNumber = 2;}
            if (i == 3)
                { heldNumber = 3; }
            if (i == 4)
                { heldNumber = 4;}
            if (i == 0) //on exit from char buttons set i as 0
                { heldNumber = 0;}
        }
        else if (dragableHeld == false)
        {
            if (i >= 1)
            {
                onChar = true;
            }
            else
            {
                onChar = false;
            }
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

    public void DisplayInfoBox(int statNumber){
        infoBoxes[statNumber].SetActive(true);
    }
    public void CloseInfoBox(int statNumber){
        infoBoxes[statNumber].SetActive(false);
    }    
    //change stat menu THIS IS WHAT YOURE WORKING ON
    public void ChangeStatMenu(int someNumber){ //0 = left, 1 = right
        if(someNumber == 1 && currentMenu < menuNames.Length -1){
            currentMenu++;
        }
        else if(someNumber == 1 && currentMenu == menuNames.Length -1){
            currentMenu = 0;
        }
        if(someNumber == 0 && currentMenu > 0){
            currentMenu--;
        }
        else if (someNumber == 0 && currentMenu == 0){
            currentMenu = 2;
        }
        if(currentMenu == 0){
            statDisplay.SetActive(true);
            movesDisplay.SetActive(false);
            gearDisplay.SetActive(false);
            menuName.text = menuNames[0];
        }
        if(currentMenu == 1){
            statDisplay.SetActive(false);
            movesDisplay.SetActive(true);
            gearDisplay.SetActive(false);
            menuName.text = menuNames[1];
        }
        if(currentMenu == 2){
            statDisplay.SetActive(false);
            movesDisplay.SetActive(false);
            gearDisplay.SetActive(true);
            menuName.text = menuNames[2];
        }
    }
    //closing menu
    public void BeginGame(){
        //triggered by pressing start button
        this.gameObject.SetActive(false);
        movesHolder.SetActive(true);
    }
}
