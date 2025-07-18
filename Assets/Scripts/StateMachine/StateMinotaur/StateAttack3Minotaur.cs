using StateMachine.StateMinotaur;
using UnityEngine;

namespace StateMachine.Attack3
{
    public class StateAttac3kMinotaur : MinotaurState
    {
        private float animDuration = 1.2f; // ← bạn có thể thay đúng với animation thật
        private float timer;
        public StateAttac3kMinotaur(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine)
        : base(minotaur, stateMachine)
        {
        }
        public override void Enter()
        {
            base.Enter();
            minotaur.animator.SetTrigger("Attack3");
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