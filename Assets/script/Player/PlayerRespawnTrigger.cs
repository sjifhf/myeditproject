using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerRespawnTrigger : MonoBehaviour
{
    public float distance = 2f, xdistance = 0, zdistance, ydistance;
    public Transform player,aim;

    void Start()
    {
        tpplayertoaim();
        if (player == null)
            {
                player = GameObject.FindWithTag("Player").transform;
            }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 如果碰到 DeathZone，重生
        if (other.CompareTag("DeathZone"))
        {
            tpplayertoaim();
        }
    }
    void tpplayertoaim()
    {
            xdistance = player.position.x - transform.position.x;
            zdistance = player.position.z - transform.position.z;
            ydistance = player.position.y - transform.position.y;
            player.GetComponent<CharacterController>().enabled = false;
            player.position = aim.position + new Vector3(0,1,0);
            player.GetComponent<CharacterController>().enabled = true;
    }
}
