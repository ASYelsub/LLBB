using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    int activeMoveSet = 1;
    public Text[] moveText = new Text[11]; 
    public void DisplayActiveMoveset(int i)
    {
        if(i == 1)
        {
            activeMoveSet = 1;
        }
        else if (i == 2)
        {
            activeMoveSet = 2;
        }
        else if (i == 3)
        {
            activeMoveSet = 3;
        }
        else if (i == 4)
        {
            activeMoveSet = 4;
        }
    }
}
