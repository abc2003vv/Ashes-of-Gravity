using StateMachine.idleCarbState;
using StateMachine.walkingCrab;
using UnityEngine;
namespace StateMachine.ControlCrabs
{
    public class CrabControl : MonoBehaviour
    {
        public DataEnemyCrab datacontrol;
        public Animator animator { get; private set; }
        public CrabStateMachine state { get; private set; }
        private Rigidbody _rb;
        private bool _isGrounded;
        private float _currentMoveSpeed = 0f;
        [SerializeField] private LayerMask targetMask;
        void Start()
        {
            animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            if (datacontrol != null && datacontrol.animatorController != null)
            {
                animator.runtimeAnimatorController = datacontrol.animatorController;
                state = new CrabStateMachine();
                state.AddState(new IdleCrabState(this, state));
                state.AddState(new WalkingCrabState(this, state));
                state.Initialize(state.GetState<IdleCrabState>());
            }
        }
        void statemove()
        {
            if (_isGrounded)
            {
                Vector3 moveDirection = new Vector3(transform.forward.x, 0, transform.forward.z).normalized);
                _currentMoveSpeed = datacontrol.moveSpeed * Time.deltaTime;
                _rb.MovePosition(transform.position + moveDirection * _currentMoveSpeed);
            }
        }
        void Update()
        {
            if (state != null)
            {
                state.LogicUpdate();
                if (checkNearPlayerRadius())
                {
                    state.ChangeState(state.GetState<WalkingCrabState>());
                }
            }
        }
        private bool checkNearPlayerRadius()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, datacontrol.checkNearPlayerRadius, targetMask);
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}