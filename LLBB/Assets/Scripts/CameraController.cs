using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform cameraTransform;
    int cameraState; // 0 = top down, 1 = 45 degrees
    float cameraLerpSpeed = 1;
    void Start()
    {
        cameraState = 0;
        cameraTransform = GetComponent<Transform>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && cameraState == 0){
            changeCamera(0);
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && cameraState == 1){
            changeCamera(1);
        }
    }

    public void changeCamera(int cameraNumber){
        if(cameraNumber == 0){
        //to 45 degrees one
            float yPos = 6;
            float zPos = -9;
            Vector3 goTo = new Vector3(0,yPos,zPos);
            cameraTransform.position = Vector3.Lerp(transform.position,goTo,cameraLerpSpeed);

            float degrees = 45;
            Vector3 to = new Vector3(degrees,0,0);
            cameraTransform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, cameraLerpSpeed);
            cameraState = 1;
        }
        else if(cameraNumber == 1){
        //to top down
            float yPos = 10;
            float zPos = 0;
            Vector3 goTo = new Vector3(0,yPos,zPos);
            cameraTransform.position = Vector3.Lerp(transform.position,goTo,cameraLerpSpeed);
            float degrees = 90;
            Vector3 to = new Vector3(degrees,0,0);
            cameraTransform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, cameraLerpSpeed);
            cameraState = 0;
        }


    }
}
