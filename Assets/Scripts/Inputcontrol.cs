using System;
using System.Collections;
using System.Collections.Generic;
using StateMachine.CharacterController;
using UnityEngine;
using UnityEngine.UI;
public class Inputcontrol : MonoBehaviour
{
    public Button AttackSliceButton;
    public Button JumpButton;
    public Button AttackChopButton;
    public Character character;
    void Start()
    {
        if (JumpButton != null)
        {
            JumpButton.onClick.AddListener(OnJumpButtonClicked);
        }
        if (AttackSliceButton != null)
        {
            AttackSliceButton.onClick.AddListener(OnAttackSliceButtonClicked);
        }
        if (AttackChopButton != null)
        {
            AttackChopButton.onClick.AddListener(OnAttackChopButtonClicked);
        }
    }
    private void OnAttackChopButtonClicked()
        {
        if (character != null)
            {
                //character.onClickAttackChopButton();
            }
            // Assuming you have a reference to the character script
        }

    private void OnAttackSliceButtonClicked()
    {
       if (character != null)
        {
            //character.onClickAttackSliceButton();
        }
        // Assuming you have a reference to the character script
    }

    public void OnJumpButtonClicked()
    {
        if (character != null)
        {
           //  character.onClickJumpButton();
        }
        // Assuming you have a reference to the character script
    }
}
