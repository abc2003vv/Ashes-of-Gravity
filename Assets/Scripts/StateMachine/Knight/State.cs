using StateMachine.CharacterController;
using StateMachine.CharacterMachine;

namespace StateMachine.CharacterState {

public abstract class State
    {
        protected Character character;
        protected CharacterStateMachine stateMachine;

        protected State(Character character, CharacterStateMachine stateMachine)
        {
            this.character = character;
            this.stateMachine = stateMachine;
        }
    
        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
    } }