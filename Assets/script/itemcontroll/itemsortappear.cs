using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsortappear : MonoBehaviour
{
    public float speed = 10f;          // ���~�X�{�t��
    public bool invisible = true;    // ���~�O�_����
    public Vector3 origform, finalpos;
    public bool upactive = false, downactive = false;
    // Start is called before the first frame update
    void Start()
    {
        invisible = true;
        origform = transform.position;
        finalpos = origform + new Vector3(0, 300, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (invisible)
            {
                upactive = true;
            }
            else if (!invisible)
            {
                downactive = true;
            }

        }

        if (upactive)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalpos, speed * Time.deltaTime);
            if (transform.position == finalpos)
            {
                upactive = false;
                invisible = false;
            }
        }
        if (downactive)
        {
            transform.position = Vector3.MoveTowards(transform.position, origform, speed * Time.deltaTime);
            if (transform.position == origform)
            {
                downactive = false;
                invisible = true;
            }
        }
    }
}
