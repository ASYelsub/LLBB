using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickChar : MonoBehaviour
{
    public Transform activeCharTransform;
    public bool hoverOverDragable = false;
    public bool dragableHeld = false;
    public Camera cam;
    public Vector3 mousePos;
    public Vector3 originalPos;
    public Transform charButton1, charButton2, charButton3, charButton4;
    int mouseOverNumber = 0;
    public Text char1Text, char2Text, char3Text, char4Text;
    public bool letGo = false;
    int heldNumber = 0;
   
    public void Awake()
    {
        originalPos = activeCharTransform.position;
    }
    public void Update()
    {
        if (dragableHeld == true)
        {
            activeCharTransform.position = Input.mousePosition;
        }
        else if(dragableHeld == false || hoverOverDragable == false)
        {
            activeCharTransform.position = originalPos;
        }
    }

    public void MouseHover()
    {
        hoverOverDragable = true;
    }
    public void MouseNotHover()
    {
        hoverOverDragable = false;
    }
    public void OnMouseDown()
    {
        dragableHeld = true;
        letGo = false;
    }
    public void OnMouseUp()
    {
        dragableHeld = false;
       //mouseOverNumber = 0;
       //Debug.Log("This runs");
       letGo = true;
        SetChar();
    }
  
    public void OverChar(int i)
    {
        if (dragableHeld == true)
        {
            Debug.Log("OverChar plus letGo");
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
    void SetChar()
    {
        
        if (heldNumber == 1)
        { char1Text.text = "hi";char2Text.text = "C2";char3Text.text = "C3"; char4Text.text = "C4"; }
        if (heldNumber == 2)
        { char1Text.text = "C1"; char2Text.text = "hi"; char3Text.text = "C3"; char4Text.text = "C4"; }
        if (heldNumber == 3)
        { char1Text.text = "C1"; char2Text.text = "C2"; char3Text.text = "hi"; char4Text.text = "C4"; }
        if (heldNumber == 4)
        { char1Text.text = "C1"; char2Text.text = "C2"; char3Text.text = "C3"; char4Text.text = "hi"; }
        if (heldNumber == 0)
        { char1Text.text = "C1"; char2Text.text = "C2"; char3Text.text = "C3"; char4Text.text = "C4"; }
    }

    public void BeginGame()
    {
        this.gameObject.SetActive(false);
    }
}
