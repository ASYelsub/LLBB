using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveButtonManager : MonoBehaviour
{
    public List<MoveButton> MoveButtons;

    [Serializable]
    public struct MoveButton
	{
        public Button uiButton;
        public CombatMoveType moveTypeToDisplay;
        public MoveButton(Button b, CombatMoveType c)
		{
            uiButton = b;
            moveTypeToDisplay = c;
		}

        public MoveButton(Button b)
		{
            uiButton = b;
            moveTypeToDisplay = CombatMoveType.EXAMPLE;
		}

        public void UpdateCombatType(CombatMoveType c)
		{
            moveTypeToDisplay = c;
		}
	}

    private void Start()
    {
        List<Button> buttons = new List<Button>(GetComponentsInChildren<Button>());
        MoveButtons = CreateMoveButtonList(buttons);
    }

    private List<MoveButton> CreateMoveButtonList(List<Button> buttons)
    {
        List<MoveButton> newMoveButtons = new List<MoveButton>();
        foreach (Button b in buttons)
        {
            b.GetComponentInChildren<Text>().text = "Move: " + (newMoveButtons.Count + 1).ToString();
            newMoveButtons.Add(new MoveButton(b));
        }
        return newMoveButtons;
    }


}
