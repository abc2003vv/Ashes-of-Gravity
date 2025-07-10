using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
namespace StateMachine.AttackSliceState
{
    public class Attack_ChopState : State
    {
        public  Attack_ChopState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            character.animator.SetTrigger("Attack_Chop");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            //character.animator.ResetTrigger("Attack_Chop");
        }
    }
}