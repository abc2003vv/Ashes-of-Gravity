using System.Collections;
using System.Collections.Generic;
using StateMachine.CharacterController;
using UnityEngine;
using UnityEngine.UI;
public class Inputcontrol : MonoBehaviour
{
    public Button JumpButton;
    void Start()
    {
        if (JumpButton != null)
        {
            JumpButton.onClick.AddListener(OnJumpButtonClicked);
        }
    }
    public void OnJumpButtonClicked()
    {
        // Assuming you have a reference to the character script
        Character character = FindObjectOfType<Character>();
        if (character != null)
        {
           character.onClickJumpButton();
        }
    }
}
