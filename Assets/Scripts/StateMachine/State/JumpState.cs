using System.Runtime.InteropServices;
using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
using StateMachine.idleState;
using StateMachine.JumpLandState;
using UnityEngine;
namespace StateMachine.JumpState
{
    /// <summary>
    /// JumpState represents the state where the character is jumping.
    /// It handles the jump logic and transitions back to IdleState when grounded.
    /// </summary>
    public class jumpState : State
    {
        private float _maxJumpHeight;

        public jumpState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("JumpState Enter");
            character.animator.SetBool("isJump", true);
            _maxJumpHeight = character.transform.position.y; 
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (character.transform.position.y > _maxJumpHeight)
                _maxJumpHeight = character.transform.position.y;
            if (character._rb.velocity.y < 0 && character.transform.position.y < _maxJumpHeight)
            {
                if (character.CheckRayCast(1f))
                {
                    stateMachine.ChangeState(stateMachine.GetState<jumpLandState>());
                }
            }
        }

        public override void PhysicsUpdate()
        {
             base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            character.animator.SetBool("isJump",false);
           
        }
    }
}