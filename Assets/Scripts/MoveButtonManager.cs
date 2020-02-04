using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveButtonManager : MonoBehaviour
{
    private static MoveButtonManager moveManager;
    public static List<MoveButton> MoveButtons;
    public List<MoveButton> DebugMoveButtons;
    public static BaseUnit FocusUnit;

    #region Move Button Struct
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
            Debug.Log("Update to: " + c);
            moveTypeToDisplay = c;
        }

        public void AddUnitAttackListener(BaseUnit b, CombatMoveType c)
        {
            uiButton.onClick.AddListener(() => b.BroadcastUnitAttacked(c));
        }
    }
    #endregion

    private void Start()
    {
        if (moveManager == null) { moveManager = this; } else { Destroy(this); }
        List<Button> buttons = new List<Button>(GetComponentsInChildren<Button>());
        MoveButtons = CreateMoveButtonList(buttons);
    }

    public static void SetFocusUnit(BaseUnit b)
    {
        if (FocusUnit != null)
        {
            for (int j = 0; j < MoveButtons.Count; j++)
            {
                MoveButtons[j].uiButton.onClick.RemoveAllListeners();
            }
        }
        FocusUnit = b;
        for (int i = 0; i < b.UnitCombatMoves.Count; i++)
        {
            Button bu = MoveButtons[i].uiButton;
            MoveButtons[i] = new MoveButton(bu, b.UnitCombatMoves[i]);
            MoveButtons[i].AddUnitAttackListener(b, MoveButtons[i].moveTypeToDisplay);
        }

        moveManager.DebugMoveButtons = new List<MoveButton>(MoveButtons);
    }

    public static void GenerateMoveButtons()
    {
        MoveButtons = CreateMoveButtonList(new List<Button>(moveManager.GetComponentsInChildren<Button>()));
    }

    private static  List<MoveButton> CreateMoveButtonList(List<Button> buttons)
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
