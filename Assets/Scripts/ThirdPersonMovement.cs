using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraPivot;

    private CharacterController controller;
    private Animator animator;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(h, 0f, v).normalized;

        if (input.magnitude >= 0.1f)
        {
            // Lấy hướng xoay từ camera pivot
            Vector3 forward = cameraPivot.forward;
            Vector3 right = cameraPivot.right;

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 moveDir = forward * input.z + right * input.x;

            controller.Move(moveDir * moveSpeed * Time.deltaTime);

            // Quay nhân vật theo hướng di chuyển
            Quaternion lookRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            // Truyền speed vào animator
            animator.SetFloat("Speed", input.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
