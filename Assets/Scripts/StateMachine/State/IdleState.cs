using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
namespace StateMachine.idleState
{
    /// <summary>
    /// IdleState represents the state where the character is not performing any action.
    /// It can transition to other states like RunState based on input or conditions.
    /// </summary>
    public class IdleState : State
    {
        public IdleState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

        /// <summary>
        /// Enter method is called when the state is entered.
        public override void Enter()
        {
            base.Enter();

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

        }

        public override void Exit()
        {
            base.Exit();
            character.animator.SetBool("isIdle", false);
        }
    }
}