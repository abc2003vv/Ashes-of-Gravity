using System.Collections;
using System.Collections.Generic;
using StateMachine.CharacterMachine;
using StateMachine.idleState;
using UnityEngine;
namespace StateMachine.CharacterController
{
    public class Character : MonoBehaviour
    {
        public DataControl dataControl;
        public Animator animator { get; private set; }
        public CharacterStateMachine stateMachine { get; private set; }

        private Rigidbody _rb;

        void Awake()
        {
            animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            animator.runtimeAnimatorController = dataControl.animatorController;

            stateMachine = new CharacterStateMachine();
            stateMachine.Initialize(new IdleState(this, stateMachine));
        }

        void Update()
        {
            stateMachine.CurrentState?.LogicUpdate();
        }

        void FixedUpdate()
        {
            stateMachine.CurrentState?.PhysicsUpdate();
        }

    }
}