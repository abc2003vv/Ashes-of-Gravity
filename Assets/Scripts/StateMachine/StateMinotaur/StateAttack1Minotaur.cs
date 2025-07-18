using StateMachine.StateMinotaur;
using UnityEngine;

namespace StateMachine.Attack1
{
    public class StateAttack1Minotaur : MinotaurState
    {
         private float animDuration = 1.2f; 
        private float timer;

        public StateAttack1Minotaur(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine)
        : base(minotaur, stateMachine)
        {
        }
        public override void Enter()
        {
            base.Enter();
            minotaur.animator.SetTrigger("Attack1");
            timer = 0f;
        }

        public override void LogicUpdate()
        {
             timer += Time.deltaTime;

        if (timer >= animDuration)
        {
            stateMachine.ChangeState(stateMachine.GetState<IdleStateMinotaur>());
            minotaur.isAttacking = false;
        }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}