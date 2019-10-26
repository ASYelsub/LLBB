using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharMovement : MonoBehaviour
{
    public Transform charOne,charTwo,charThree,charFour;
    public static int charInt;
    Transform activeTransform;
    
    void Start(){
        activeTransform = charOne;
    }
    public void setActiveCharacter(int charInt){
        Debug.Log("setActiveCharacter is triggered by" + charInt);
        if (charInt == 1){
            activeTransform = charOne;
            Debug.Log("active transform = " + activeTransform.ToString());
        }
        if (charInt == 2){
            activeTransform = charTwo;
            Debug.Log("active transform = " + activeTransform.ToString());
        }
        if (charInt == 3){
            activeTransform = charThree;
            Debug.Log("active transform = " + activeTransform.ToString());
        }
        if (charInt == 4){
            activeTransform = charFour;
            Debug.Log("active transform = " + activeTransform.ToString());
        }
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.UpArrow)){
            activeTransform.position += activeTransform.position + new Vector3(0f,0f,.1f);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            
        }
        if(Input.GetKey(KeyCode.DownArrow)){

        }
    }
}
