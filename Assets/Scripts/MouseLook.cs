using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Cài đặt Camera")]
    public Transform target;                        // Nhân vật (player)
    public Vector3 offset = new Vector3(0f, 5f, -8f); // Vị trí camera so với player
    public float smoothTime = 0.1f;                 // Độ mượt khi camera di chuyển

    [Header("Xoay chuột")]
    public float mouseSensitivity = 3f;             // Nhạy chuột
    public float minPitch = -35f;                   // Giới hạn nhìn xuống
    public float maxPitch = 75f;                    // Giới hạn nhìn lên

    [Header("Auto Reset sau khi thả chuột")]
    public bool autoReturn = true;                  // Bật tính năng tự xoay về sau lưng
    public float returnToBehindSpeed = 3f;          // Tốc độ quay lại

    private float yaw;                              // Góc xoay ngang
    private float pitch = 10f;                      // Góc xoay dọc mặc định
    private bool isRotating = false;                // Đang xoay chuột phải
    private Vector3 currentVelocity;                // Tốc độ dùng cho SmoothDamp

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("⚠️ MouseLook: Chưa gán Target.");
            enabled = false;
            return;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        yaw = target.eulerAngles.y; // Khởi đầu camera ở sau lưng nhân vật
    }

    void LateUpdate()
    {
        if (target == null) return;

        HandleMouseInput();
        UpdateCameraPosition();
    }

    void HandleMouseInput()
    {
        // Nhấn chuột phải để xoay camera
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Thả chuột phải
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Nếu đang giữ chuột phải → xoay tự do
        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            yaw += mouseX;
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }
        else if (autoReturn)
        {
            // Tự động quay lại sau lưng nhân vật (mượt)
            float targetYaw = target.eulerAngles.y;
            yaw = Mathf.LerpAngle(yaw, targetYaw, Time.deltaTime * returnToBehindSpeed);
        }
    }

    void UpdateCameraPosition()
    {
        // Tính góc xoay thành Quaternion
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Tính vị trí cần đến
        Vector3 desiredPosition = target.position + rotation * offset;

        // Mượt hóa di chuyển camera
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);

        transform.position = smoothedPosition;

        // Nhìn vào vị trí gần đầu nhân vật
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
