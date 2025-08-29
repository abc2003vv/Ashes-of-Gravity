using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
namespace StateMachine.JumpLandState
{
    /// <summary>
    /// JumpState represents the state where the character is jumping.
    /// It handles the jump logic and transitions back to IdleState when grounded.
    /// </summary> 
    public class jumpLandState : State
    {
        public jumpLandState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }
        public override void Enter()
        {
            base.Enter();
            character.animator.SetBool("isJumpLand", true);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            character.animator.SetBool("isJumpLand", false);
        }
    }
}