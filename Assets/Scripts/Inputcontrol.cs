using System;
using System.Collections;
using System.Collections.Generic;
using StateMachine.CharacterController;
using UnityEngine;
using UnityEngine.UI;
public class Inputcontrol : MonoBehaviour
{
    public Button JumpButton;
    public Character character;
    void Start()
    {
        if (JumpButton != null)
        {
            JumpButton.onClick.AddListener(OnJumpButtonClicked);
        }
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
