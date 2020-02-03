using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this thing lets you move characters by clicking on the screen via raycast
public class ActiveCharMovement : MonoBehaviour
{

    public PickChar pickChar;
    public Transform[] charTransform = new Transform[4];
    public int charInt;
    //bool char1Moving;
    Transform activeTransform;
    bool gamePaused = false;

    //public Transform oldTransform;
    //public Transform newTransform;
    Vector3[] destinationVect = new Vector3[]{
        Vector3.zero,
        Vector3.zero,
        Vector3.zero,
        Vector3.zero
    };

    public Transform[] targetTransform = new Transform[4];
    public SpriteRenderer[] targetSR = new SpriteRenderer[4];
    float[] currentSpeed = new float[4];
    void Start(){
        activeTransform = charTransform[0];
            targetSR[0].enabled = true;
            targetSR[1].enabled = true;
            targetSR[2].enabled = true;
            targetSR[3].enabled = true;
        
    }

    //need to update these names to not these characters
    public void getCharacterSpeed(string characterName, float characterSpeed){
        if(characterName == "Vesuvius"){
            currentSpeed[0] = characterSpeed;
        }
        else if (characterName == "Carmeline"){
            currentSpeed[1] = characterSpeed;
        }
        else if (characterName == "Bobby"){
            currentSpeed[2] = characterSpeed;            
        }
        else if (characterName == "Urania"){
            currentSpeed[3] = characterSpeed;
        }
    }
    public void setActiveCharacter(int charInt){
        this.charInt = charInt - 1;
        if (charInt == 1){
            activeTransform = charTransform[0];
                targetSR[0].enabled = true;
                targetSR[1].enabled = false;
                targetSR[2].enabled = false;
                targetSR[3].enabled = false;
        }
        if (charInt == 2){
            activeTransform = charTransform[1];
                targetSR[0].enabled = false;
                targetSR[1].enabled = true;
                targetSR[2].enabled = false;
                targetSR[3].enabled = false;
        }
        if (charInt == 3){
            activeTransform = charTransform[2];
                targetSR[0].enabled = false;
                targetSR[1].enabled = false;
                targetSR[2].enabled = true;
                targetSR[3].enabled = false;
        }
        if (charInt == 4){
            activeTransform = charTransform[3];    
                targetSR[0].enabled = false;
                targetSR[1].enabled = false;
                targetSR[2].enabled = false;
                targetSR[3].enabled = true;
        }
         Debug.Log("setActiveCharacter is triggered by" + charInt);
    }

    void Update(){
//        Debug.Log(pickChar.onChar);
        if(!gamePaused){
            
                if(Input.GetKeyDown(KeyCode.Mouse0) && pickChar.onChar == false){
                RayCastBaby();      
                }
                
                for(int i = 0; i < 4; i++ ){
                    if (destinationVect[i] != Vector3.zero){
                        Vector3 playerYPlace = new Vector3(destinationVect[i].x, 0f, destinationVect[i].z);
                        charTransform[i].position = Vector3.MoveTowards(charTransform[i].position,playerYPlace,currentSpeed[i]);
                        targetTransform[i].position = destinationVect[i];//targetPrefab.Instantiate
                        if(Vector3.Distance(activeTransform.position,destinationVect[i]) < 0.001f){
                            destinationVect[i] = Vector3.zero;
                        }
                    }
                if(Input.GetKeyDown(KeyCode.Space)){
                gamePaused = true;}
            }
            
            
        }
        else if (gamePaused){
            if(Input.GetKeyDown(KeyCode.Mouse0) && pickChar.onChar == false)
            {
                RayCastBaby();
                targetTransform[charInt].position = destinationVect[charInt];
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                gamePaused = false;
            }
        }
        
        //}     
    }
    void RayCastBaby(){
   
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float mouseRayDistance = 10000f;
            RaycastHit rayHit = new RaycastHit();
            //Debug.DrawRay(mouseRay.origin, mouseRay.direction*mouseRayDistance,Color.yellow);
            if(Physics.Raycast(mouseRay,out rayHit,mouseRayDistance)){    
                    //save old "active transform"
                    
                    //isMoving = true;
                    destinationVect[charInt] = new Vector3(rayHit.point.x,rayHit.point.y,rayHit.point.z);
                    //Debug.Log("tempVect = " + destinationVect[charInt].x + "," + destinationVect[charInt].z);
                    //find new "active transform" through rayHit.position    
                    //lerp between the two over void Update               

        
             
            }
            //if(Physics.Raycast(mouseRay,out rayHit))
    }
}
