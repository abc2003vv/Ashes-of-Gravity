
using StateMachine.ControlCrabs;

namespace StateMachine.StateCrabControl
{
    public abstract class StateCrab
    {
        protected CrabControl crabControl;
        protected CrabStateMachine stateMachine;
        protected StateCrab(CrabControl crabControl, CrabStateMachine stateMachine)
        {
            this.crabControl = crabControl;
            this.stateMachine = stateMachine;
        }
        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }   
    }
}