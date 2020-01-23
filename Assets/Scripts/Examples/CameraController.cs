using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform pivotTransform;
    int cameraState; // 0 = top down, 1 = 45 degrees
    float cameraLerpSpeed = 1;
    float parentRoatation;
    void Start()
    {
        cameraState = 0;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 mouseInput = new Vector3(0f,mouseX*10f,0f);

        if(Input.GetKey(KeyCode.Mouse1)){
            transform.parent.Rotate(mouseInput);
            parentRoatation = transform.parent.rotation.y;
        }
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
            float zPos = -9;
            Vector3 goTo = new Vector3(0,yPos,zPos);
            transform.position = Vector3.Lerp(transform.position,goTo,cameraLerpSpeed);

            float degrees = 45;
            Vector3 to = new Vector3(degrees,0,0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, cameraLerpSpeed);
            cameraState = 1;
        }
        else if(cameraNumber == 1){
        //to top down
            float yPos = 10;
            float zPos = 0;
            Vector3 goTo = new Vector3(0,yPos,zPos);
            transform.position = Vector3.Lerp(transform.position,goTo,cameraLerpSpeed);
            float degrees = 90;
            Vector3 to = new Vector3(degrees,0,0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, cameraLerpSpeed);
            cameraState = 0;
        }


    }
}
