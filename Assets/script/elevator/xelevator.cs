using UnityEngine;

public class xelevator : MonoBehaviour
{
    public float detectDistance = 2f;     // 最遠偵測距離
    public LayerMask wallLayer;            // 指定牆壁圖層0
    public float speed = 2f;            // 平台上升速度
    public float xway = 5f,height=5f,zway=5f;           // 上升高度
    public KeyCode triggerKey = KeyCode.E; // 觸發按鍵

    private Vector3 startPos,latestpos;           // 起始位置
    private bool movingUp = false;      // 是否在上升中
    public float ontop = 0f; // 玩家是否在平台上
    public Transform player;           // 玩家 Transform

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float CheckWallDistance(Vector3 direction)
        {
            RaycastHit hit;

            // 發射射線檢測
            if (Physics.Raycast(player.transform.position, direction, out hit, detectDistance, wallLayer))
            {
                return hit.distance; // 射線到牆的距離
            }

            return -1f; // -1 表示沒打到牆
        }
        ontop = CheckWallDistance(-player.transform.up);//玩家正下方是不是方塊
        // 玩家在平台上且按下按鍵
        if (ontop != -1 && Input.GetKeyDown(triggerKey))
        {
            movingUp = true;
            // 玩家成為子物件 → 平台移動時會帶著他
           player.SetParent(transform);
        }

        // 平台移動
        if (movingUp)
        {
            Vector3 targetPos = startPos + new Vector3(xway, height, zway);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            
            player.position = player.position + (transform.position - latestpos);
            latestpos = transform.position;

        }

        if (transform.position == startPos + new Vector3(xway, height, zway) || ontop == -1)
        {
            movingUp = false;
            // 平台到達目標位置後，解除玩家的子物件關係
            /*if (player != null)
            {
                player.SetParent(null);
            }*/
        }

        if (ontop == -1 && transform.position != startPos)//玩家離開平台
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }
}
