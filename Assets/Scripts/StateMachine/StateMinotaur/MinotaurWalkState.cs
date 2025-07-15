using StateMachine.StateMinotaur;
namespace StateMachine.StateMinotaur
{
    /// <summary>
    /// Represents the walking state of the Minotaur.
    /// In this state, the Minotaur moves towards the player at a defined speed.
    /// </summary>
    public class MinotaurWalkState : MinotaurState
    {
        public MinotaurWalkState(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine)
            : base(minotaur, stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            minotaur.animator.SetBool("isWalking", true);
        }

        public override void LogicUpdate()
        {

        }

        public override void Exit()
        {
            base.Exit();
            minotaur.animator.SetBool("isWalking", false);
        }
    }
}