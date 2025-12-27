using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public float detectDistance = 2f;     // 最遠偵測距離
    public LayerMask wallLayer;            // 指定牆壁圖層
    public Transform cameraTransform;

    // 四個方向的距離
    public float frontDistance=1;
    public float backDistance;
    public float leftDistance;
    public float rightDistance;
    public int cycle;//角色跟攝影機是否旋轉

    int a = 0,b=0;
    //float c=0;
    void Start()
    {
        float CheckWallDistance(Vector3 direction)
        {
            RaycastHit hit;

            // 發射射線檢測
            if (Physics.Raycast(transform.position, direction, out hit, detectDistance, wallLayer))
            {
                return hit.distance; // 射線到牆的距離
            }

            return -1f; // -1 表示沒打到牆
        }
        // 正前方
        frontDistance = CheckWallDistance(transform.forward);

        // 正後方
        backDistance = CheckWallDistance(-transform.forward);

        // 左邊
        leftDistance = CheckWallDistance(-transform.right);

        // 右邊
        rightDistance = CheckWallDistance(transform.right);

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        float CheckWallDistance(Vector3 direction)
        {
            RaycastHit hit;

            // 發射射線檢測
            if (Physics.Raycast(transform.position, direction, out hit, detectDistance, wallLayer))
            {
                return hit.distance; // 射線到牆的距離
            }

            return -1f; // -1 表示沒打到牆
        };

        if (frontDistance <= 2f && frontDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            a = 0;
            b = 0;
        }
        else if (backDistance <= 2f && backDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            /*// 轉180度後正前方
            backDistance = CheckWallDistance(transform.forward);

            // 轉180度正後方
            frontDistance = CheckWallDistance(-transform.forward);

            // 轉180度左邊
            rightDistance = CheckWallDistance(-transform.right);

            // 轉180度右邊
            leftDistance = CheckWallDistance(transform.right);*/
            a = 2;
            b = 0;
        }
        else if (leftDistance <= 2f && leftDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 270, 0);
            /*// 轉270度正前方
            leftDistance = CheckWallDistance(transform.forward);

            // 轉270度正後方
            rightDistance = CheckWallDistance(-transform.forward);

            // 轉270度左邊
            backDistance = CheckWallDistance(-transform.right);

            // 轉270度右邊
            frontDistance = CheckWallDistance(transform.right);*/
            a = 3;
            b = 0;
        }
        else if (rightDistance <= 2f && rightDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            /* // 轉90度正前方
             rightDistance = CheckWallDistance(transform.forward);

             // 轉90度正後方
             leftDistance = CheckWallDistance(-transform.forward);

             // 轉90度左邊
             frontDistance = CheckWallDistance(-transform.right);

             // 轉90度右邊
             backDistance = CheckWallDistance(transform.right);*/
            a = 1;
            b = 0;
        }
        else
        {
            b = 1;
        }

        switch (a)
        {
            case 0:
                // 正前方
                frontDistance = CheckWallDistance(transform.forward);

                // 正後方
                backDistance = CheckWallDistance(-transform.forward);

                // 左邊
                leftDistance = CheckWallDistance(-transform.right);

                // 右邊
                rightDistance = CheckWallDistance(transform.right);
                break;
            case 2:
                // 轉180度後正前方
                backDistance = CheckWallDistance(transform.forward);
                // 轉180度正後方
                frontDistance = CheckWallDistance(-transform.forward);
                // 轉180度左邊
                rightDistance = CheckWallDistance(-transform.right);
                // 轉180度右邊
                leftDistance = CheckWallDistance(transform.right);
                break;
            case 3:
                // 轉270度正前方
                leftDistance = CheckWallDistance(transform.forward);
                // 轉270度正後方
                rightDistance = CheckWallDistance(-transform.forward);
                // 轉270度左邊
                backDistance = CheckWallDistance(-transform.right);
                // 轉270度右邊
                frontDistance = CheckWallDistance(transform.right);
                break;
            case 1:
                // 轉90度正前方
                rightDistance = CheckWallDistance(transform.forward);
                // 轉90度正後方
                leftDistance = CheckWallDistance(-transform.forward);
                // 轉90度左邊
                frontDistance = CheckWallDistance(-transform.right);
                // 轉90度右邊
                backDistance = CheckWallDistance(transform.right);
                break;
            }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && b == 1)
        {
            /*c=transform.eulerAngles.y;
            for (int i = 0; i <= 90; i++)
            {
                transform.Rotate(0, +1, 0);
            }
            transform.rotation = Quaternion.Euler(0,c+90, 0);*/
            cycle = 1;
            if (a!=3) a++;
            else
                a=0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && b == 1)
        {
            /*c = transform.eulerAngles.y;
            for (int i = 1; i <= 90; i++)
            {
                transform.Rotate(0, -1, 0);
            }
            transform.rotation = Quaternion.Euler(0, c - 90, 0);*/
            cycle = 2;
            if (a != 0) a--;
            else
                a = 3;
        }
    }
}