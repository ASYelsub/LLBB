using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCombatButtonBehavior : MonoBehaviour
{
    public int CharacterIndex;
    public Button CharacterButton;
    public PlayerUnit CharacterCombative;
    public StatSliderDisplay HpDisplay, StaminaDisplay;

    private void Start()
    {
        CharacterButton = GetComponent<Button>();
        HpDisplay = new StatSliderDisplay(transform.Find("HpSlider").GetComponent<Slider>());
        StaminaDisplay = new StatSliderDisplay(transform.Find("StaminaSlider").GetComponent<Slider>());
    }

    public void SetFocusToCharacter()
    {
        if(CharacterCombative != null) { MoveButtonManager.SetFocusUnit(CharacterCombative); }
    }

    public void SetCharacterCombative(PlayerUnit p)
    {
        CharacterCombative = p;
    }

    private void Update()
    {
        if (CharacterCombative != null)
        {
            HpDisplay.StatToDisplay = CharacterCombative.CurrentHP;
            StaminaDisplay.StatToDisplay = CharacterCombative.CurrentStamina;
            HpDisplay.DisplayStats();
            StaminaDisplay.DisplayStats();
        } else
        {
            CharacterCombative = CharacterIndex <= PlayerUnitManager.ActivePlayerUnits.Count ? PlayerUnitManager.ActivePlayerUnits[CharacterIndex] : null;
        }
    }
}

[System.Serializable]
public struct StatSliderDisplay
{
    public Slider StatSlider;
    public CombatStat StatToDisplay;
    public float MaxValue;
    public StatSliderDisplay(Slider s)
    {
        StatSlider = s;
        StatToDisplay = new CombatStat();
        MaxValue = StatToDisplay.CurrentValue;
    }

    public void DisplayStats()
    {
        StatSlider.maxValue = MaxValue;
        StatSlider.value = StatToDisplay.CurrentValue;
    }
}
