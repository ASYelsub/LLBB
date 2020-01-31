using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    Vector3 playerClick;
    Vector3 storedRotation;
    int cameraState;
    public float moveSensitivity;
    public Camera thisCamera;

    float fov = 0;

    void Start(){
        cameraState = 1;
    }
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");
        if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){
            playerClick = Input.mousePosition; //0,0 is at bottom left of screen
            //Debug.Log(playerClick);
        }
        if(Input.GetMouseButton(1)){
            Vector3 mouseVector = playerClick+Input.mousePosition;
            //Debug.Log(mouseVector.y);
            transform.parent.Rotate(0f,mouseY*10f,0f);
            transform.parent.Rotate(0f,mouseX*10f,0f);  
            storedRotation = transform.parent.eulerAngles;
        }
        if(Input.GetMouseButton(2)){
            transform.parent.transform.Translate(0f, 0f, mouseY*-moveSensitivity);
            transform.parent.transform.Translate(mouseX*-moveSensitivity, 0f, 0);
        }
        if(Input.GetMouseButtonUp(1)){
            storedRotation = transform.parent.eulerAngles;
            //Debug.Log(storedRotation); //rotation of pivot when last rotated camera
        }

        fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * 10f;
        fov = Mathf.Clamp(fov, 5f, 80f);
        Camera.main.fieldOfView = fov;

        if (Input.GetKeyDown(KeyCode.Tab) && cameraState == 0){
            //Debug.Log(cameraState);
                float degrees = 90;
                Vector3 goTo = new Vector3(0,10,0);
                Vector3 to = new Vector3(degrees,storedRotation.y,0);
                transform.eulerAngles = Vector3.Slerp(new Vector3(0,0,0),to,1);
                transform.localPosition = Vector3.Slerp(transform.localPosition,goTo,1);
                CameraStateSwitcher(0);
            }
        else if (Input.GetKeyDown(KeyCode.Tab) && cameraState == 1){
            //Debug.Log(cameraState);
                float degrees = 45;
                Vector3 goTo = new Vector3(0,6,-8);
                Vector3 to = new Vector3(degrees,storedRotation.y,0);
                transform.eulerAngles = Vector3.Slerp(new Vector3(0,0,0),to,1);
                transform.localPosition = Vector3.Slerp(transform.localPosition,goTo,1);
                CameraStateSwitcher(1);
            }
            
        
    }
    void CameraStateSwitcher(int stateSwitch){
        if(stateSwitch == 0){
            cameraState = 1;
        }
        if(stateSwitch == 1){
            cameraState = 0;
        }
        //Debug.Log("State Switched");
    }
}
