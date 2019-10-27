using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharMovement : MonoBehaviour
{
    public Transform charOne,charTwo,charThree,charFour;
    public static int charInt;
    //bool char1Moving;
    Transform activeTransform;
    //public Transform oldTransform;
    //public Transform newTransform;
    bool isMoving = false;
    Vector3 tempVect;
    
    
    void Start(){
        activeTransform = charOne;
    }
    public void setActiveCharacter(int charInt){
        Debug.Log("setActiveCharacter is triggered by" + charInt);
        if (charInt == 1){
            activeTransform = charOne;
        }
        if (charInt == 2){
            activeTransform = charTwo;
        }
        if (charInt == 3){
            activeTransform = charThree;
        }
        if (charInt == 4){
            activeTransform = charFour;
        }
    }

    void Update(){

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float mouseRayDistance = 10000f;
        RaycastHit rayHit = new RaycastHit();
        Debug.DrawRay(mouseRay.origin, mouseRay.direction*mouseRayDistance,Color.yellow);
        if(Physics.Raycast(mouseRay,out rayHit,mouseRayDistance)){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            
                   //save old "active transform"
                   
                   isMoving = true;
                   Vector3 tempVect = new Vector3(rayHit.point.x,0f,rayHit.point.z);
                   Debug.Log("tempVect = " + tempVect.x + "," + tempVect.z);
                   //find new "active transform" through rayHit.position    
                   //lerp between the two over void Update               
            }
             
        } 
            
        //Debug.Log("RaycastHit = " + rayHit.point);
        //Debug.Log(isMoving);
        /*if (isMoving){
            activeTransform.Translate(new Vector3(rayHit.point.x,0f,rayHit.point.z));
        } */      
    }
}
