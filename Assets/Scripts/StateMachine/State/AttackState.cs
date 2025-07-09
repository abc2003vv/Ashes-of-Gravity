using UnityEngine;
using System.Diagnostics;
using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;
using System.Runtime.InteropServices;
namespace StateMachine.Attackstate
{
/// <summary>
public class AttackState : State
{
    public AttackState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

        /// <summary>
        /// Enter method is called when the state is entered.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            int random = Random.Range(0, 3); // 0, 1, 2
              character.animator.SetInteger("Attackindex", random);
                character.animator.SetTrigger("Attack"); // Trigger transition từ Locomotion → Attack
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