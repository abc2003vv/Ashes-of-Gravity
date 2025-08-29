using ScriptableObjects.CrabEnemy;
using StateMachine.idleCarbState;
using StateMachine.walkingCrab;
using Unity.VisualScripting;
using UnityEngine;
namespace StateMachine.ControlCrabs
{
    public class CrabControl : MonoBehaviour
    {
        public CrabsEnemySO datacontrol;
        public Animator animator { get; private set; }
        public CrabStateMachine state { get; private set; }
        private Rigidbody _rb;
        private bool _isGrounded;
        private float groundCheckDistance = 1f;
        private float _currentMoveSpeed = 0f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private float groundCheckRadius = 2f;
        [SerializeField] private LayerMask groundLayer;
        private Transform targetMove;
        void Start()
        {
            animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            targetMove = GameManager.Instance._playerTransform;
                animator.runtimeAnimatorController = datacontrol.dataEnemyCrab.AnimatorController;
                state = new CrabStateMachine();
                state.AddState(new IdleCrabState(this, state));
                state.AddState(new WalkingCrabState(this, state));
                state.Initialize(state.GetState<IdleCrabState>());
        }

        public void statemove()
        {
            if (_isGrounded && targetMove != null)
            {
                Vector3 moveDirection = (targetMove.position - transform.position).normalized;
                moveDirection.y = 0;
                //_currentMoveSpeed = datacontrol.moveSpeed * Time.deltaTime;
                _rb.MovePosition(transform.position + moveDirection * _currentMoveSpeed);
                if (moveDirection != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                }
            }
        }
        void Update()
        {
            if (state == null) return;

            // chạy logic của state hiện tại
            state.CurrentState?.LogicUpdate();

            if (state.CurrentState is IdleCrabState)
            {
                if (checkNearPlayerRadius())
                {
                    if (checkGrounded())
                        state.ChangeState(state.GetState<WalkingCrabState>());
                }
            }
        }

        private bool checkGrounded()
        {
            bool isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
            _isGrounded = isGrounded;
            Debug.Log("Ground check: " + isGrounded);
            return isGrounded;
        }

        private bool checkNearPlayerRadius()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, datacontrol.dataEnemyCrab.CheckNearPlayerRadius, targetMask);
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Debug.Log(" Crab check is near Player!");
                    return true;
                }
            }
            return false;
        }
    }
}