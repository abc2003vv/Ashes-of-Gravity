using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
using StateMachine.idleState;
using UnityEngine;
namespace StateMachine.JumpState
{
    /// <summary>
    /// JumpState represents the state where the character is jumping.
    /// It handles the jump logic and transitions back to IdleState when grounded.
    /// </summary>;
    public class jumpState : State
    {
        private bool isGrounded;

        public jumpState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            character.animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isGrounded)
            {
                stateMachine.ChangeState(stateMachine.GetState<IdleState>());
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            // Check if the character is grounded
            isGrounded = Physics.Raycast(character.transform.position, Vector3.down, 1.1f);
        }

        public override void Exit()
        {
            base.Exit();
            character.animator.SetBool("isJumping",false);
        }
    }
}