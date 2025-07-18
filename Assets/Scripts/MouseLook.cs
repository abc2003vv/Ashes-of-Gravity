using UnityEngine;
using UnityEngine.EventSystems; // Cần thiết để kiểm tra touch/chuột có đang tương tác UI

public class MouseOrTouchLook : MonoBehaviour
{
    public Transform target;                    // Player
    public Vector3 offset = new Vector3(0, 3, -6);
    public float mouseSensitivity = 2f;
    public float smoothTime = 0.1f;
    public float returnSpeed = 2f;

    private float yaw = 0f;
    private float pitch = 15f;
    private Vector3 currentVelocity;
    private bool isDragging = false;

    private float targetYaw => target.eulerAngles.y;

    void Start()
    {
        yaw = target.eulerAngles.y;
    }

    void Update()
    {
        HandleInput();
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);

        // Luôn nhìn vào nhân vật
        Vector3 lookTarget = target.position + Vector3.up * 1.5f;
        transform.rotation = Quaternion.LookRotation(lookTarget - transform.position);
    }

    void HandleInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Nếu đang nhấn vào UI (như joystick) thì bỏ qua
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            yaw += mouseX;
        }
        else
        {
            yaw = Mathf.LerpAngle(yaw, targetYaw, Time.deltaTime * returnSpeed);
        }

#elif UNITY_ANDROID || UNITY_IOS
        // Nếu đang nhấn vào UI thì bỏ qua
        if (Input.touchCount > 0 && EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                isDragging = true;
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                isDragging = false;

            if (isDragging && touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x * mouseSensitivity * 0.1f;
                yaw += deltaX;
            }
        }
        else
        {
            isDragging = false;
            yaw = Mathf.LerpAngle(yaw, targetYaw, Time.deltaTime * returnSpeed);
        }
#endif
    }
}
