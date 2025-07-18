using StateMachine.Attack1;
using StateMachine.Attack2;
using StateMachine.Attack3;
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
        public bool isAttacking = false;
        public Animator animator { get; private set; }
        public MinotaurStateMachine stateMachine { get; private set; }
        private Rigidbody _rb;
        private float _currentSpeed = 0f;
        private float _attackTimer = 0f;
        private float _attackDelay = 0f;
        private bool _isAttackCounting = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            if (dataControl != null && dataControl.animatorController != null)
            animator.runtimeAnimatorController = dataControl.animatorController;
            stateMachine = new MinotaurStateMachine();
            stateMachine.AddState(new IdleStateMinotaur(this, stateMachine));
            stateMachine.AddState(new MinotaurWalkState(this, stateMachine));
            stateMachine.AddState(new RunStateMinotaur(this, stateMachine));
            stateMachine.AddState(new StateAttack1Minotaur(this, stateMachine));
            stateMachine.AddState(new StateAttack2Minotaur(this, stateMachine));
            stateMachine.AddState(new StateAttac3kMinotaur(this, stateMachine));
            stateMachine.Initialize(stateMachine.GetState<IdleStateMinotaur>());
        }
        /// <summary>
        /// Controls the speed of the Minotaur based on whether it is running or walking.
        /// /// If the game is paused, the speed is set to zero.
        /// </summary>
        /// 
       void TriggerRandomAttack()
        {
            isAttacking = true;

            int randomAttack = Random.Range(1, 4);
            if (randomAttack == 1)
                stateMachine.ChangeState(stateMachine.GetState<StateAttack1Minotaur>());
            else if (randomAttack == 2)
                stateMachine.ChangeState(stateMachine.GetState<StateAttack2Minotaur>());
            else
                stateMachine.ChangeState(stateMachine.GetState<StateAttac3kMinotaur>());
        }

        void HandlesAttackMinotaur()
        {
            if (isAttacking) return;

            if (checkNearPlayerRadius())
            {
                if (!_isAttackCounting)
                {
                    StartAttackCountdown(); 
                }

                _attackTimer -= Time.deltaTime;
                if (_attackTimer <= 0f)
                {
                    TriggerRandomAttack();
                    _isAttackCounting = false;
                }
            }
            else
            {
                _isAttackCounting = false;
            }
        }

        /// <summary>
        /// Controls Attack.
        /// </summary>
            void ControlSpeed()
    {
        if (GameManager.Instance.IsPaused)
        {
            _currentSpeed = 0f;
            return;
        }

        if (stateMachine.CurrentState is IdleStateMinotaur)
        {
            _currentSpeed = 0f;
            return;
        }

        if (isAttacking)
        {
            _currentSpeed = 0f;
            Debug.Log("Minotaur đang attack nên không di chuyển.");
            return;
        }

        if (isRunning)
        {
            _currentSpeed = dataControl.Runspeed;
            stateMachine.ChangeState(stateMachine.GetState<RunStateMinotaur>());
            Debug.Log("chage to RunStateMinotaur");
        }
        else
        {
            _currentSpeed = dataControl.walkingSpeed;
            stateMachine.ChangeState(stateMachine.GetState<MinotaurWalkState>());
            Debug.Log("chage to WalkStateMinotaur");
        }

        MoveTowardsTarget(); // chỉ được gọi nếu không phải Idle
    }
 
        private void StartAttackCountdown()
        {
            _attackDelay = 0.5f; 
            _attackTimer = _attackDelay;
            _isAttackCounting = true;
        }
        /// <summary>
        /// Updates the Minotaur's state every frame.
        private bool checkNearPlayerRadius()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, dataControl.checkNearPlayerRadius, targetMask);
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Debug.Log("is near Player!");
                    return true;
                }
            }
            return false;
        }
        void Update()
        {
            Transform detectedPlayer = DetectTarget(dataControl.checkPlayerRadius, targetMask);

            if (detectedPlayer != null)
            {
                player = detectedPlayer;
                if (IsPlayerNear())
                {
                    isRunning = false;
                    Debug.Log("Đi bộ");
                }
                else
                {
                    isRunning = true;
                    Debug.Log(" Chạy");
                }

                ControlSpeed();
            }
            else
            {
                player = null;
                isRunning = false;
                stateMachine.ChangeState(stateMachine.GetState<IdleStateMinotaur>());
            }
            HandlesAttackMinotaur();
            stateMachine.Update();
            }

        /// <summary>       
        /// Moves the Minotaur towards the target player if it exists and the current speed is greater than zero.
        /// </summary>  
        void MoveTowardsTarget()
        {
            if (player == null || _currentSpeed <= 0f) return;
            Vector3 dir = player.position - transform.position;
            transform.position += dir.normalized * _currentSpeed * Time.deltaTime;
            dir.y = 0f; 
            Quaternion lookRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(
            transform.rotation, lookRot, 8f * Time.deltaTime);
        }
        private bool IsPlayerNear()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, dataControl.walkingDistance, targetMask);
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Debug.Log("Phát hiện Player gần!");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Detects the player within a specified radius using Physics.OverlapSphere.
        private Transform DetectTarget(float radius, LayerMask targetMask)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, radius, targetMask);
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Debug.Log("Phát hiện Player!");
                    isRunning = true; 
                    return hit.transform;
                }
            }
            return null;
        }
       
    }
}