using System.Collections;
using StateMachine.Attackstate;
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
        public Rigidbody _rb;
        private Vector3 _moveDirection;
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
            stateMachine.AddState(new AttackState(this, stateMachine));
            stateMachine.Initialize(stateMachine.GetState<IdleState>());
            
            EnableJoystickInput(isJoystickInput);
        }
         public bool CheckRayCast(float distance)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, distance))
                {
                    return hit.collider.CompareTag("Ground");
                }
                return false;
            }
        private void EnableJoystickInput(bool enabled)
        {
            isJoystickInput = enabled;
            inputCanvas?.gameObject.SetActive(enabled);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
        void Update()
        {
            HandleInput(); 
            stateMachine.CurrentState?.LogicUpdate(); 
        }
        public void onClickAttackButton()
        {
            stateMachine.ChangeState(stateMachine.GetState<AttackState>());
            // if (stateMachine.CurrentState is AttackState) return;
            // if (stateMachine.CurrentState is IdleState || stateMachine.CurrentState is RunState)
            // {
            //     stateMachine.ChangeState(stateMachine.GetState<AttackState>());
            // }
            // else
            // {
            //     stateMachine.ChangeState(stateMachine.GetState<IdleState>());
            // }
           
        }
        public void onClickJumpButton()
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * dataControl.jumpForce, ForceMode.Impulse);
                _isGrounded = false;
                stateMachine.ChangeState(stateMachine.GetState<jumpState>());
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

            // --- Quay nhân vật luôn, kể cả khi đang nhảy ---
            if (_moveDirection != Vector3.zero)
            {
                Quaternion lookRot = Quaternion.LookRotation(_moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 10f);
            }

            // --- Chuyển state chỉ khi không ở Jump hoặc JumpLand ---
            if (!(stateMachine.CurrentState is jumpState) && !(stateMachine.CurrentState is jumpLandState) &&
             !(stateMachine.CurrentState is AttackState))
            {
                if (_moveDirection != Vector3.zero)
                {
                    if (!(stateMachine.CurrentState is RunState))
                        stateMachine.ChangeState(stateMachine.GetState<RunState>());
                }
                else
                {
                    if (!(stateMachine.CurrentState is IdleState))
                        stateMachine.ChangeState(stateMachine.GetState<IdleState>());
                }
            }
            if (stateMachine.CurrentState is jumpLandState)
            {
                stateMachine.ChangeState(stateMachine.GetState<IdleState>());
            }
            ///
            /// 
            
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
