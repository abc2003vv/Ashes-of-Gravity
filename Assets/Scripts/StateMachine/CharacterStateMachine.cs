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
        private Dictionary<System.Type, State> _states = new Dictionary<System.Type, State>();
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
            CurrentState?.Enter();             
        }
        public void AddState(State state)
        {
            var type = state.GetType();
            if (!_states.ContainsKey(type))
            {
                _states.Add(type, state);
            }
        }

        public T GetState<T>() where T : State
        {
            return _states[typeof(T)] as T;
        }


         public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
        
    }
}