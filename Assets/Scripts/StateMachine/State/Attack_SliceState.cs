using System.Diagnostics;
using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
namespace StateMachine.AttackSliceState
{
    /// <summary>
    /// Attack_SliceState represents a specific attack action where the character performs a slicing attack.
    /// It inherits from the base State class and implements the necessary methods for entering, updating, and exiting the state.
    /// </summary>
    public class Attack_SliceState : State
    {
        public Attack_SliceState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            character.animator.SetTrigger("Attack_Slice");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            //character.animator.ResetTrigger("Attack_Slice");
        }
    }
}