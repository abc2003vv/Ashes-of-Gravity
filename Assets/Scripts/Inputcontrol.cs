using System;
using System.Collections;
using System.Collections.Generic;
using StateMachine.CharacterController;
using UnityEngine;
using UnityEngine.UI;
public class Inputcontrol : MonoBehaviour
{
    public Button AttackButton;
    public Button JumpButton;
    public Character character;
    void Start()
    {
        if (JumpButton != null)
        {
            JumpButton.onClick.AddListener(OnJumpButtonClicked);
        }
        if (AttackButton != null)
        {
            AttackButton.onClick.AddListener(OnAttackButtonClicked);
        }
    }

    private void OnAttackButtonClicked()
    {
       if (character != null)
        {
            character.onClickAttackButton();
        }
        // Assuming you have a reference to the character script
    }

    public void OnJumpButtonClicked()
    {
        if (character != null)
        {
             character.onClickJumpButton();
        }
        // Assuming you have a reference to the character script
    }
}
