using System.Collections.Generic;

namespace StateMachine.StateMinotaur
{
    public class MinotaurStateMachine
    {
        /// <summary>
        /// MinotaurMachine is responsible for managing the current state of a Minotaur.
        /// It allows transitioning between different states and handles the entry and exit logic.
        /// </summary>
        private Dictionary<System.Type, MinotaurState> _states = new Dictionary<System.Type, MinotaurState>();
        public MinotaurState CurrentState { get; private set; }

        public void Initialize(MinotaurState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }
        public void ChangeState(MinotaurState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }
        public void AddState(MinotaurState state)
        {
            var type = state.GetType();
            if (!_states.ContainsKey(type))
            {
                _states.Add(type, state);
            }
        }

        public T GetState<T>() where T : MinotaurState
        {
            return _states[typeof(T)] as T;
        }


        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }

    }
}