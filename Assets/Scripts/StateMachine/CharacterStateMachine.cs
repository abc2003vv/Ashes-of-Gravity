using System.Collections;
using System.Collections.Generic;
using StateMachine.CharacterState;
using UnityEngine;
namespace StateMachine.CharacterMachine
{
    /// <summary>
    /// CharacterStateMachine is responsible for managing the current state of a character.
    /// It allows transitioning between different states and handles the entry and exit logic.
    /// </summary>
    public class CharacterStateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}