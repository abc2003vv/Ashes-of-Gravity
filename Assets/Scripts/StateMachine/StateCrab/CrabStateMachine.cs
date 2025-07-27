using System.Collections;
using System.Collections.Generic;
using StateMachine.StateCrabControl;
using UnityEngine;

public class CrabStateMachine : MonoBehaviour
{ 
        private Dictionary<System.Type, StateCrab> _states = new Dictionary<System.Type, StateCrab>();
        public StateCrab CurrentState { get; private set; }

        public void Initialize(StateCrab startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }
        public void ChangeState(StateCrab newState)
        {
            CurrentState?.Exit();              
            CurrentState = newState;           
            CurrentState?.Enter();             
        }
        public void AddState(StateCrab state)
        {
            var type = state.GetType();
            if (!_states.ContainsKey(type))
            {
                _states.Add(type, state);
            }
        }

        public T GetState<T>() where T : StateCrab
        {
            return _states[typeof(T)] as T;
        }


         public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
        
    }

