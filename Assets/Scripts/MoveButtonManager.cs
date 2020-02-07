using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveButtonManager : MonoBehaviour
{
    private static MoveButtonManager moveManager;
    public static List<MoveButton> MoveButtons;
    public static BaseUnit FocusUnit;

    #region Move Button Struct
    [Serializable]
    public struct MoveButton
    {
        public Button uiButton;
        public Text buttonText;
        public CombatMoveType moveTypeToDisplay;
        private float TimeStamp;
        public MoveButton(Button b, CombatMoveType c)
        {
            uiButton = b;
            buttonText = b.GetComponentInChildren<Text>();
            moveTypeToDisplay = c;
            buttonText.text = c.GetMoveByType().MoveName;
            TimeStamp = DateTime.Now.Second;
        }

        public MoveButton(Button b)
        {
            uiButton = b;
            buttonText = b.GetComponentInChildren<Text>();
            buttonText.text = "";
            moveTypeToDisplay = CombatMoveType.EXAMPLE;
            TimeStamp = DateTime.Now.Second;
        }

        public bool FinishedCoolDown()
        {
            return (DateTime.Now.Second - TimeStamp) > moveTypeToDisplay.GetMoveByType().CoolDown;
        }

        public void SetTimeClicked(float f)
        {
            TimeStamp = f;
        }

        public void AddUnitAttackListener(BaseUnit b, CombatMoveType c)
        {
            uiButton.onClick.AddListener(() => b.BroadcastUnitAttacked(c));
        }

        public void ToggleUiButton(bool setAs)
        {
            uiButton.interactable = setAs;
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
                MoveButtons[j].ToggleUiButton(true);
            }
        }
        FocusUnit = b;
        int numberOfMoves = b.UnitCombatMoves.Count;
        for (int i = 0; i < MoveButtons.Count; i++)
        {
            if (i < numberOfMoves)
            {
                Button bu = MoveButtons[i].uiButton;
                MoveButtons[i] = new MoveButton(bu, b.UnitCombatMoves[i]);
                MoveButtons[i].ToggleUiButton(true);
                MoveButtons[i].AddUnitAttackListener(b, MoveButtons[i].moveTypeToDisplay);
                //MoveButtons[i].uiButton.onClick.AddListener(() => SetTimeStamp(MoveButtons[i]));
            } else
            {
                MoveButtons[i].ToggleUiButton(false);
                MoveButtons[i].buttonText.text = "";
            }
        }
    }

    public static void GenerateMoveButtons()
    {
        MoveButtons = CreateMoveButtonList(new List<Button>(moveManager.GetComponentsInChildren<Button>()));
    }

    public static void SetTimeStamp(MoveButton m)
    {
        Debug.Log(DateTime.Now.Second);
        m.SetTimeClicked(DateTime.Now.Second);
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
