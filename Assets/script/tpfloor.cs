
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tpfloor : MonoBehaviour
{
    public float distance = 2f, xdistance = 0, zdistance, ydistance;
    public Transform player,aim;//角色座標跟目的地座標
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xdistance = player.position.x - transform.position.x;
        zdistance = player.position.z - transform.position.z;
        ydistance = player.position.y - transform.position.y;
        if (xdistance < distance && xdistance > -distance && zdistance < distance && zdistance > -distance && ydistance <= distance-1.1 && ydistance >= -distance + 1.1)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.position = aim.position + new Vector3(0,1,0);
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
