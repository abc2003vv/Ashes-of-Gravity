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
            crabControl.animator.SetBool("iswalking", true);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            crabControl.statemove();
        }

        public override void Exit()
        {
            base.Exit();
            crabControl.animator.SetBool("iswalking", false);
        }
    }
}