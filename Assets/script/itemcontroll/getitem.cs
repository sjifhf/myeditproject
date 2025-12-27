using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class getitem : MonoBehaviour
{
    public Transform player;
    public float distance = 3f,xdistance=0,zdistance,ydistance;
    public int activejump = 1;

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
        if (xdistance < distance && xdistance > -distance && zdistance < distance && zdistance > -distance)
        {
            if(ydistance <= distance && ydistance >= -distance)
            {
                activejump = 0;
                base.gameObject.SetActive(false);
            }
        }

        transform.Rotate(0, 1, 0);
    }
}
