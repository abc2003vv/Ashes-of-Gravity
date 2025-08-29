using ScriptableObjects.BossMinotaur;
using StateMachine.StateMinotaur;
namespace StateMachine.StateMinotaur
{
    public class MinotaurState
    {
        public ControllStateMinotaur minotaur;
        private BossSO dataControl;

        // Reference to the state machine for Minotaur
        protected ControllStateMinotaur minotaurController;
        protected MinotaurStateMachine stateMachine;

        public MinotaurState(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine)
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