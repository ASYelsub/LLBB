using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    int actStr,actWis,actChar,actFort,actInt,actAgil,actStam,actEnd;
    public ActiveCharMovement activeCharMovement;
    public GameObject stats, skills, gear;
    public GameObject myCanvas;
    public bool isCanvasOn = true;
    public void Update(){

        if(Input.GetKeyDown(KeyCode.Escape) && isCanvasOn == false){
            myCanvas.SetActive(true);
            isCanvasOn = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isCanvasOn == true){
            myCanvas.SetActive(false);
            isCanvasOn = false;
        }
    }
    public void CloseInventory(){
        myCanvas.SetActive(false);
    }
    public void OpenSubInventory(int i){
        if(i == 0){ //skills
            stats.SetActive(false);
            skills.SetActive(true);
            gear.SetActive(false);
        }
        else if (i == 1){ //stats
            stats.SetActive(true);
            skills.SetActive(false);
            gear.SetActive(false);
        }
        else if (i == 2){ //gear
            stats.SetActive(false);
            skills.SetActive(false);
            gear.SetActive(true);
        }
    }
}
