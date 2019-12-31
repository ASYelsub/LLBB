using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickChar : MonoBehaviour
{
    public Transform activeCharTransform;
    public Camera cam;
    public Text[] charText = new Text[4];
    int characterNumber = 0;
    public string[] charNames = new string[5];
    public Text activeName;
    bool hoverOverDragable = false;
    bool dragableHeld = false;
    Vector3 mousePos;
    Vector3 originalPos;
    int heldNumber = 0;
   
    public void Awake(){
        activeName.text = charNames[characterNumber];
        originalPos = activeCharTransform.position;

    }
    public void ChangeActiveCharArray(int direction){ //0 = left, 1 = right
        if(direction == 1 && characterNumber < charNames.Length - 1){
            characterNumber++;
            activeName.text = charNames[characterNumber];
        }
        else if(direction == 1 && characterNumber == charNames.Length - 1){
            characterNumber = 0;
            activeName.text = charNames[characterNumber];
        }
        if(direction == 0 && characterNumber > 0){
            characterNumber --;
            activeName.text = charNames[characterNumber];
        }
        else if(direction == 0 && characterNumber == 0){
            characterNumber = 4;
            activeName.text = charNames[characterNumber];
        }
    }
    public void Update(){
        Debug.Log(characterNumber);
        mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,-1);
        if (dragableHeld == true){
            activeCharTransform.position = mousePos;}
        else if(dragableHeld == false || hoverOverDragable == false){
            activeCharTransform.position = originalPos;}
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
    void SetChar(){
        if (heldNumber == 1)
            { charText[0].text = "hi"; charText[1].text = "C2"; charText[2].text = "C3"; charText[3].text = "C4"; }
        if (heldNumber == 2)
            { charText[0].text = "C1"; charText[1].text = "hi"; charText[2].text = "C3"; charText[3].text = "C4"; }
        if (heldNumber == 3)
            { charText[0].text = "C1"; charText[1].text = "C2"; charText[2].text = "hi"; charText[3].text = "C4"; }
        if (heldNumber == 4)
            { charText[0].text = "C1"; charText[1].text = "C2"; charText[2].text = "C3"; charText[3].text = "hi"; }
    }

    //setting who "character" is when being dragged

    //closing menu
    public void BeginGame(){
        //triggered by pressing start button
        this.gameObject.SetActive(false);
    }
}
