using System.Collections;
using StateMachine.CharacterMachine;
using StateMachine.idleState;
using StateMachine.JumpLandState;
using StateMachine.JumpState;
using UnityEngine;

namespace StateMachine.CharacterController
{
    public class Character : MonoBehaviour
    {
        [Header("Input & Camera")]
        public VariableJoystick variableJoystick;
        public Canvas inputCanvas;
        public bool isJoystickInput = true;
        public Transform cameraTransform;

        [Header("Data")]
        public DataControl dataControl;
        public Animator animator { get; private set; }
        public CharacterStateMachine stateMachine { get; private set; }

        private Vector3 _moveDirection;
        private Rigidbody _rb;
        private bool _isGrounded;

        void Start()
        {
            animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();

            if (dataControl != null && dataControl.animatorController != null)
                animator.runtimeAnimatorController = dataControl.animatorController;

           stateMachine = new CharacterStateMachine();

            stateMachine.AddState(new IdleState(this, stateMachine));
            stateMachine.AddState(new RunState(this, stateMachine));
            stateMachine.AddState(new jumpState(this, stateMachine));
            stateMachine.AddState(new jumpLandState(this, stateMachine));
            stateMachine.Initialize(stateMachine.GetState<IdleState>());
            
            EnableJoystickInput(isJoystickInput);
        }

        private void EnableJoystickInput(bool enabled)
        {
            isJoystickInput = enabled;
            inputCanvas?.gameObject.SetActive(enabled);
        }

        void Update()
        {
            HandleInput(); 
            stateMachine.CurrentState?.LogicUpdate(); 
        }
        public void onClickJumpButton()
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * dataControl.jumpForce, ForceMode.Impulse);
                stateMachine.ChangeState(stateMachine.GetState<jumpState>());
            }
            else if (!_isGrounded)
            {
                stateMachine.ChangeState(stateMachine.GetState<jumpLandState>());
            }
        }
        
        private void HandleInput()
        {
            if (!isJoystickInput || cameraTransform == null) return;

            Vector2 input = variableJoystick.Direction;

            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;
            camForward.y = 0f;
            camRight.y = 0f;
            camForward.Normalize();
            camRight.Normalize();

            _moveDirection = (camForward * input.y + camRight * input.x).normalized;

            if (_moveDirection != Vector3.zero)
            {
                Quaternion lookRot = Quaternion.LookRotation(_moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 10f);
                stateMachine.ChangeState(stateMachine.GetState<RunState>());
            }
            else
            {
                stateMachine.ChangeState(stateMachine.GetState<IdleState>());
            }

        }

        void FixedUpdate()
        {
            if (_moveDirection.magnitude > 0.01f)
            {
                Vector3 velocity = _moveDirection * dataControl.moveSpeed;
                _rb.MovePosition(_rb.position + velocity * Time.fixedDeltaTime);
            }

            stateMachine.CurrentState?.PhysicsUpdate(); 
        }
    }
}
