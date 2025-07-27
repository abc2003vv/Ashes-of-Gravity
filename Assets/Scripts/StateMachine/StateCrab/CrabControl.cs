using StateMachine.idleCarbState;
using UnityEngine;
namespace StateMachine.ControlCrabs
{
    public class CrabControl : MonoBehaviour
    {
        public DataEnemyCrab datacontrol;
        public Animator animator { get; private set; }
        public CrabStateMachine state { get; private set; }
        public Rigidbody _rb;
        private Vector3 _moveDirection;
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
                state.Initialize(state.GetState<IdleCrabState>());
            }
        }
        void Update()
        {
            checkNearPlayerRadius();
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