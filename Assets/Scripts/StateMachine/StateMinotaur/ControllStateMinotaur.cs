using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine.StateMinotaur
{
    /// <summary>
    /// ControllStateMinotaur is a placeholder class that can be used to control the Minotaur's state.
    /// It can be extended to include specific control logic for the Minotaur.
    /// </summary>
    public class ControllStateMinotaur : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] LayerMask targetMask;
        public DataBoss dataControl;
        public Transform player;
        public bool isRunning;
        public Animator animator { get; private set; }
        public MinotaurStateMachine stateMachine { get; private set; }
        private Rigidbody _rb;
        private float currentSpeed = 0f;
        private float _rotateSpeed = 5f;

        void Start()
        {
            animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            if (dataControl != null && dataControl.animatorController != null)
            animator.runtimeAnimatorController = dataControl.animatorController;
            stateMachine = new MinotaurStateMachine();
            stateMachine.AddState(new IdleStateMinotaur(this, stateMachine));
            stateMachine.AddState(new MinotaurWalkState(this, stateMachine));
            stateMachine.Initialize(stateMachine.GetState<IdleStateMinotaur>());
        }
         void ControlSpeed()
            {
                if (GameManager.Instance.IsPaused)
                {
                    currentSpeed = 0f;     
                    return;
                }

                    currentSpeed = isRunning
                        ? dataControl.Runspeed
                    : dataControl.walkingSpeed;
            }
        void Update()
        {
                if(DetectTarget(dataControl.checkPlayerRadius, targetMask))
            {
                MoveTowardsTarget();
                stateMachine.ChangeState(stateMachine.GetState<MinotaurWalkState>());
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
            }
        }
        void MoveTowardsTarget()
        {
            if (player == null || currentSpeed <= 0f) return;
            Vector3 dir = player.position - transform.position;
            transform.position += dir.normalized * currentSpeed * Time.deltaTime;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, lookRot, 8f * Time.deltaTime);
        }
        private void HandleEnemy()
        {
            
        }
        private Transform DetectTarget(float radius, LayerMask targetMask)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, radius, targetMask);
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Debug.Log("Phát hiện Player!");
                    return hit.transform;
                }
            }
            return null;
        }
       
    }
}