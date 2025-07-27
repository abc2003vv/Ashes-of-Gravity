using StateMachine.ControlCrabs;
using StateMachine.StateCrabControl;
namespace StateMachine.idleCarbState
{
    /// <summary>
    public class IdleCrabState : StateCrab
    {
        public IdleCrabState(CrabControl crab, CrabStateMachine stateMachine) : base(crab, stateMachine) { }

        /// <summary>
        public override void Enter()
        {
            base.Enter();
            crabControl.animator.SetBool("isDle", true);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}