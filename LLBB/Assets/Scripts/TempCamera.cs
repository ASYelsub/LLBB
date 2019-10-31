using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCamera : MonoBehaviour
{
    Transform cameraTransform;
    public Transform pivotTransform;
    int cameraState; // 0 = top down, 1 = 45 degrees
    float cameraLerpSpeed = 1;
    float parentRoatation;

    Vector3 playerClick;
    Vector3 cameraRotation;
    void Start()
    {
        cameraState = 0;
        cameraTransform = GetComponent<Transform>();
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 mouseInput = new Vector3(0f,mouseX*10f,0f);
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            playerClick = Input.mousePosition;
            cameraRotation = transform.parent.eulerAngles;
        }
        if(Input.GetKey(KeyCode.Mouse1)){
            Vector3 mouseVector = playerClick - Input.mousePosition;
            if(mouseVector.y > 0){
                mouseVector.x = 0;
                mouseVector.z = 0;
                transform.parent.eulerAngles = cameraRotation + mouseVector;
                parentRoatation = transform.parent.rotation.y;    
            }
            if(mouseVector.y < 0){
                mouseVector.x = 0;
                mouseVector.z = 0;
                transform.parent.eulerAngles = cameraRotation + mouseVector;
                parentRoatation = transform.parent.rotation.y;    
            }
            
        }
        cameraTransform.LookAt(transform.parent);
        if(Input.GetKeyDown(KeyCode.Tab) && cameraState == 0){
            changeCamera(0);
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && cameraState == 1){
            changeCamera(1);
        }
    }

    public void changeCamera(int cameraNumber){
        float mouseX = Input.GetAxis("Mouse X");
        if(cameraNumber == 0){
        //to 45 degrees one
            float yPos = 6;
            float zPos = -Mathf.Sin(cameraTransform.eulerAngles.y)*-9;
            float xPos = Mathf.Cos(cameraTransform.eulerAngles.y)*5;
            Vector3 goTo = new Vector3(xPos,yPos,zPos);
            cameraTransform.position = Vector3.Lerp(transform.position,goTo,cameraLerpSpeed);

            float degrees = 45;
            Vector3 to = new Vector3(degrees,cameraTransform.eulerAngles.y,0);
            cameraTransform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, cameraLerpSpeed);
            cameraState = 1;
        }
        else if(cameraNumber == 1){
        //to top down
        //Transform.LookAt
            float yPos = 10;
            float zPos = -Mathf.Sin(cameraTransform.eulerAngles.y);
            float xPos = Mathf.Cos(cameraTransform.eulerAngles.y);
            Vector3 goTo = new Vector3(xPos,yPos,zPos);
            cameraTransform.position = Vector3.Lerp(transform.position,goTo,cameraLerpSpeed);
            
            float degrees = 90;
            Vector3 to = new Vector3(degrees,cameraTransform.eulerAngles.y,0);
            cameraTransform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, cameraLerpSpeed);
            cameraState = 0;
        }


    }
}
