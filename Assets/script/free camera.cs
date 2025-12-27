using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFreeCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 2f;
    private float rotX;
    private Vector3 pos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -5f, 5f);
        pos.y = Mathf.Clamp(transform.position.y, 1f, 4f);
        pos.z = Mathf.Clamp(transform.position.z, -5f, 5f);
        transform.position = pos;
        // ·Æ¹«±±¨î±ÛÂà
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotX, transform.eulerAngles.y + mouseX, 0);

        // Áä½L±±¨î²¾°Ê
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

