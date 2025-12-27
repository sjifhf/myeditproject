using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{
    [Header("控制對象")]
    public Transform player;   // 指向 Player（有 CharacterController）

    [Header("移動設定")]
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.8f;

    private CharacterController controller;
    private float yVelocity;
    private bool isGrounded;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("PlayerMovement_2D：未指定 Player");
            enabled = false;
            return;
        }

        controller = player.GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("Player 沒有 CharacterController");
            enabled = false;
        }
    }

    void Update()
    {
        if (!controller) return;

        // 1️⃣ 是否在地面
        isGrounded = controller.isGrounded;

        // 2️⃣ 跳躍 & 重力
        if (isGrounded && yVelocity < 0)
            yVelocity = -1f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

        yVelocity += gravity * Time.deltaTime;

        // 3️⃣ 撞天花板停止上升
        if ((controller.collisionFlags & CollisionFlags.Above) != 0 && yVelocity > 0)
            yVelocity = 0f;

        // 4️⃣ 2D 移動（只走 X 軸）
        float moveX = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveX, 0f, 0f);
        move.y = yVelocity;

        // 5️⃣ 移動 Player
        controller.Move(move * speed * Time.deltaTime);
    }
}
