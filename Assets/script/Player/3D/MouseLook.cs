using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("控制對象")]
    public Transform playerBody;        // Player（只轉 Y）

    [Header("視角設定")]
    public float mouseSensitivity = 100f;
    public float minPitch = -80f;
    public float maxPitch = 80f;

    [Header("狀態")]
    public bool enableLook = true;

    private float xRotation = 0f;

    void Start()
    {
        Validate();
        ApplyCursorState(enableLook);
    }

    void Update()
    {
        if (!enableLook || playerBody == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        HandlePitch(mouseY);
        HandleYaw(mouseX);
    }

    // ===== 視角處理 =====

    void HandlePitch(float mouseY)
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minPitch, maxPitch);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleYaw(float mouseX)
    {
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // ===== 工具 =====

    public void SetLookEnabled(bool enable)
    {
        enableLook = enable;
        ApplyCursorState(enable);
    }

    void ApplyCursorState(bool lockCursor)
    {
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }

    void Validate()
    {
        if (playerBody == null)
        {
            Debug.LogError("MouseLook：未指定 playerBody");
            enabled = false;
        }
    }
}
