using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickChar : MonoBehaviour
{
    public Transform activeCharTransform;
    public bool hoverOver = false;
    public bool charPicked = false;
    public Camera cam;
    public Vector3 mousePos;
    public Vector3 originalPos;
    public Transform charButton1, charButton2, charButton3, charButton4;
    int mouseOverNumber;
    public Text char1Text, char2Text, char3Text, char4Text;
    public bool letGo = false;
   
    public void Awake()
    {
        originalPos = activeCharTransform.position;
    }
    public void Update()
    {
        if (charPicked == true)
        {
            activeCharTransform.position = Input.mousePosition;
        }
        else
        {
            activeCharTransform.position = originalPos;
        }
    }

    public void MouseHover()
    {
        hoverOver = true;
    }
    public void MouseNotHover()
    {
        hoverOver = false;
    }
    public void OnMouseDown()
    {
        charPicked = true;
    }
    public void OnMouseUp()
    {
        if (mouseOverNumber != 1 || mouseOverNumber != 2 || mouseOverNumber != 3 || mouseOverNumber != 4)
        {
            mouseOverNumber = 0;
        }
        letGo = true;
    }
    public void MouseOver1()
    {
        if (charPicked == true)
        {
            mouseOverNumber = 1;
            char1Text.text = "hi";
            //SelectAction(1);
            Debug.Log("MouseOver1");
        }

    }
    public void MouseOver2()
    {
        if(charPicked == true)
        {
            mouseOverNumber = 2;
            char2Text.text = "hi";
            //SelectAction(2);
            Debug.Log("MouseOver2");
        }
    }
    public void MouseOver3()
    {
        if(charPicked == true)
        {
            mouseOverNumber = 3;
            char3Text.text = "hi";
            //SelectAction(3);
            Debug.Log("MouseOver3");
        }

    }
    public void MouseOver4()
    {
        if(charPicked == true)
        {
            mouseOverNumber = 4;
            //SelectAction(4);
            char4Text.text = "hi";
            Debug.Log("MouseOver4");
        }

    }
   public void SelectAction()
    {
        //if i = character 1,2,3,4... assign that character
        //if i = the original position or not one of those characters, charPicked = false;
        if (letGo == true)
        {
            if (mouseOverNumber == 1)
            {
                char1Text.text = "hi";
                char2Text.text = "2";
                char3Text.text = "3";
                char4Text.text = "4";
            }
            else if (mouseOverNumber == 2)
            {
                char1Text.text = "1";
                char2Text.text = "hi";
                char3Text.text = "3";
                char4Text.text = "4";
            }
            else if (mouseOverNumber == 3)
            {
                char1Text.text = "1";
                char2Text.text = "2";
                char3Text.text = "hi";
                char4Text.text = "4";
            }
            else if (mouseOverNumber == 1)
            {
                char1Text.text = "1";
                char2Text.text = "2";
                char3Text.text = "3";
                char4Text.text = "hi";
            }
            else if (mouseOverNumber == 0)
            {
                charPicked = false;
            }
        }
    }

    public void BeginGame()
    {
        this.gameObject.SetActive(false);
    }
}
