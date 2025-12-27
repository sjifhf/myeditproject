using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchitemusing : MonoBehaviour
{
    public int switchitem = 0;
    public bool heightfollow = false;
    private Vector3[] switchpos = new Vector3[7]
    {
        new Vector3(97,-47,0),
        new Vector3(160,-47,0),
        new Vector3(225,-47,0),
        new Vector3(289,-47,0),
        new Vector3(354,-47,0),
        new Vector3(418,-47,0),
        new Vector3(482,-47,0)
    };

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.y - 73 <= 1 && transform.position.y - 73 >= -1)
        {
            switchitem++;
            transform.position = switchpos[switchitem % 7];
            if (heightfollow)
            {
                transform.position += new Vector3(0, 120, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.y-73 <= 1 && transform.position.y - 73 >= -1)
        {
            if(switchitem == 0)
            {
                switchitem = 7;
            }
            switchitem--;
            transform.position = switchpos[switchitem % 7];
            if (heightfollow)
            {
                transform.position += new Vector3(0, 120, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            heightfollow = !heightfollow;
        }
    }
}
