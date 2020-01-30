using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class BaseUnit : MonoBehaviour
{
	public BaseClass UnitType;
	public Dictionary<StatType, float> UnitStats;

    void Start()
    {
        //GenerateUnitStats();
    }

    private void Update()
    {
       
    }

    public void DebugStats(){
        Debug.Log(this.name);
		for(int i = 0;i< UnitStats.Count; i++){
			Debug.Log(UnitStats.ElementAt(i).Key + ": " + UnitStats.ElementAt(i).Value);
		}
	}

    public void GenerateUnitStats()
    {
        UnitStats = new Dictionary<StatType, float>();
        if (UnitType != null && UnitType.ClassStatSettings.Length > 0)
        {
            UnitType.GenerateStats(this);
        }
    }
}
[CustomEditor(typeof(BaseUnit))]
public class UnitEditor: Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BaseUnit b = (BaseUnit)target;
        if (GUILayout.Button("Generate Unit Stats"))
        {
            b.GenerateUnitStats();
            b.DebugStats();
        }
    }
}
