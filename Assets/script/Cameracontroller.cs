using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    /*public GameObject player; // �ѦҪ��a����*/
    public Transform player;
    public Transform Maincamera;
    private WallDetector detector;
    public float followSpeed = 5f; // ��v�����H�t��
    public float playerDistance = 15;
    float a = 0, b = 0, c = -5;//��v���򨤦ⶡ�Z
    float playerfinalrotation = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        detector = player.GetComponent<WallDetector>();
        playerfinalrotation = player.transform.eulerAngles.y;
    }

    void Update()
    {
        
        Vector3 playerPos = player.transform.position;
        if (detector.cycle == 1)
        {
            playerfinalrotation += 90;
        }
        else if (detector.cycle == 2)
        {
            playerfinalrotation -= 90;
        }

        if (playerfinalrotation < 0) playerfinalrotation += 360;
        else if (playerfinalrotation > 360) playerfinalrotation -= 360;


        if (((playerfinalrotation == 0 || playerfinalrotation == 360 ) && transform.eulerAngles.y != playerfinalrotation) || (detector.frontDistance < 2f && detector.frontDistance > 0))
        {
            Debug.Log("0");
            a = 0; b = 0; c = -playerDistance;
        }
        else if ((playerfinalrotation == 180 && transform.eulerAngles.y != playerfinalrotation) || (detector.backDistance < 2f && detector.backDistance > 0))
        {
            Debug.Log("180");
            a = 0; b = 0; c = playerDistance;
        }
        else if ((playerfinalrotation == 90 && transform.eulerAngles.y != playerfinalrotation) || (detector.rightDistance < 2f && detector.rightDistance > 0))
        {
            Debug.Log("90");
            a = -playerDistance; b = 0; c = 0;
        }
        else if ((playerfinalrotation == 270 && transform.eulerAngles.y != playerfinalrotation) || (detector.leftDistance < 2f && detector.leftDistance > 0))
        {
            Debug.Log("270");
            a = playerDistance; b = 0; c = 0;
        }

        /*if (detector.cycle != 0)
        {
            playerPosy = player.eulerAngles.y;
            j = detector.cycle;
            t = playerfinalrotation;
            StartCoroutine(Rotateandfollow());
            i = 0;
            detector.cycle = 0;

        }
        else if(i==1)
        {
            
        }*/
        for (int i = 0; i < 200; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPos.x + a, playerPos.y + b, playerPos.z + c), followSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
            transform.LookAt(player);
            player.transform.LookAt(Maincamera);
            
        }
        detector.cycle = 0;
    }

    // ��v�����Ƹ��H���a
    /*IEnumerator Rotateandfollow()
    {
        
        while (playerPosy != t) 
        {
            if (j == 1)
            {
                player.Rotate(0,1,0);
            }
            else if (j == 2)
            {
                player.Rotate(0,-1,0);
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x + a, player.position.y + b,player.position.z + c), followSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.LookAt(player);
            playerPosy = player.transform.eulerAngles.y;
            if(playerPosy == t) break;
            yield return null;
        }
        i = 1;
    }*/
}
