using UnityEngine;

public class PlayerMovement_3D : MonoBehaviour
{
    [Header("控制對象")]
    public Transform player;   // 指向 Player（不是掛在 Player 上）

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
            Debug.LogError("PlayerMovement_3D：未指定 Player");
            enabled = false;
            return;
        }

        controller = player.GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("Player 身上沒有 CharacterController");
            enabled = false;
        }
    }

    void Update()
    {
        if (!controller) return;

        // 1️⃣ 是否在地面
        isGrounded = controller.isGrounded;

        // 2️⃣ 重力與跳躍
        if (isGrounded && yVelocity < 0)
            yVelocity = -1f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

        yVelocity += gravity * Time.deltaTime;

        // 3️⃣ 撞天花板清掉上升速度
        if ((controller.collisionFlags & CollisionFlags.Above) != 0 && yVelocity > 0)
            yVelocity = 0f;

        // 4️⃣ 水平移動（依 Player 朝向）
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move =
            player.right * moveX +
            player.forward * moveZ;

        move.y = yVelocity;

        // 5️⃣ 移動 Player
        controller.Move(move * speed * Time.deltaTime);
    }
}
