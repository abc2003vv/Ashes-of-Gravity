using StateMachine.ControlCrabs;
using StateMachine.StateCrabControl;
namespace StateMachine.walkingCrab
{
    public class WalkingCrabState : StateCrab
    {
        public WalkingCrabState(CrabControl crab, CrabStateMachine stateMachine) : base(crab, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            crabControl.animator.SetBool("isWalking", true);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            crabControl.animator.SetBool("isWalking", false);
        }
    }
}