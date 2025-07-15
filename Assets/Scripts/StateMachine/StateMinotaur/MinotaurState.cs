using StateMachine.StateMinotaur;
namespace StateMachine.StateMinotaur
{
    public class MinotaurState
    {
        protected ControllStateMinotaur minotaur;
        protected DataBoss dataControl;

        // Reference to the state machine for Minotaur
        protected ControllStateMinotaur minotaurController;
        protected MinotaurStateMachine stateMachine;

        protected MinotaurState(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine)
        {
            this.minotaur = minotaur;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
    }
}