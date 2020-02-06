using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PlayerUnitManager : MonoBehaviour
{
    private static PlayerUnitManager pum;
    public static List<PlayerData> ValidCharacters;
    public static List<PlayerUnit> ActivePlayerUnits;

    public static PlayerUnit ActiveUnit;

    private void Start()
    {
        if (pum == null) { pum = this; } else { Destroy(this); }
        ValidCharacters = new List<PlayerData>(Resources.LoadAll<PlayerData>("Character Data"));
        ActivePlayerUnits = new List<PlayerUnit>(FindObjectsOfType<PlayerUnit>());
        for (int i = 0; i < ValidCharacters.Count; i++)
        {
            ActivePlayerUnits[i].SetPlayerStats(ValidCharacters[i]);
        }
    }

    private void Update()
    {
        if(ActiveUnit != null) { Debug.Log(ActiveUnit.name); }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SelectEnemyTargetViaClick();
        }
    }

    public static void SetActivePlayerUnit(PlayerUnit p)
    {
        ActiveUnit = p;
    }

    public static void SetActivePlayerUnit(BaseUnit b)
    {
        if (b is PlayerUnit)
        {
            SetActivePlayerUnit(b.GetComponent<PlayerUnit>());
        }
    }

    public void SelectEnemyTargetViaClick()
    {
        if (ActiveUnit != null)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh = new RaycastHit();
            if (Physics.SphereCast(r, 3f, out rh, Mathf.Infinity))
            {
                if (rh.transform.GetComponent<BaseUnit>())
                {
                    ActiveUnit.SetTargetToEffect(rh.transform.GetComponent<BaseUnit>());
                    Debug.Log(rh.transform.name + " is now the Target of " + ActiveUnit.name);
                }
            }
        }
    }

}
