using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharMovement : MonoBehaviour
{
    public Transform[] charTransform = new Transform[4];
    public int charInt;
    //bool char1Moving;
    Transform activeTransform;
    //public Transform oldTransform;
    //public Transform newTransform;
    bool isMoving = false;
    Vector3[] destinationVect = new Vector3[]{
        Vector3.zero,
        Vector3.zero,
        Vector3.zero,
        Vector3.zero
    };
    
    
    void Start(){
        activeTransform = charTransform[0];
    }
    public void setActiveCharacter(int charInt){
        this.charInt = charInt - 1;
        if (charInt == 1){
            activeTransform = charTransform[0];
        }
        if (charInt == 2){
            activeTransform = charTransform[1];
        }
        if (charInt == 3){
            activeTransform = charTransform[2];
        }
        if (charInt == 4){
            activeTransform = charTransform[3];
        }
         Debug.Log("setActiveCharacter is triggered by" + charInt);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            RayCastBaby();
        }
            
        //Debug.Log("RaycastHit = " + rayHit.point);
        //Debug.Log(isMoving);
        //if (isMoving){
            for(int i = 0; i < 4; i++ ){
            if (destinationVect[i] != Vector3.zero){
                charTransform[i].position = Vector3.MoveTowards(charTransform[i].position,destinationVect[i],0.01f);
                if(Vector3.Distance(activeTransform.position,destinationVect[i]) < 1f){
                    destinationVect[i] = Vector3.zero;
                    }
                }
            }
            
        //}     
    }
    void RayCastBaby(){
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float mouseRayDistance = 10000f;
        RaycastHit rayHit = new RaycastHit();
        Debug.DrawRay(mouseRay.origin, mouseRay.direction*mouseRayDistance,Color.yellow);
        if(Physics.Raycast(mouseRay,out rayHit,mouseRayDistance)){    
                   //save old "active transform"
                   
                   //isMoving = true;
                   destinationVect[charInt] = new Vector3(rayHit.point.x,0f,rayHit.point.z);
                   Debug.Log("tempVect = " + destinationVect[charInt].x + "," + destinationVect[charInt].z);
                   //find new "active transform" through rayHit.position    
                   //lerp between the two over void Update               
             
        } 
    }
}
