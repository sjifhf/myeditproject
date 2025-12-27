using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationchanging : MonoBehaviour
{
    public float turningspeed = 2f;
    int finalrotation = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            finalrotation += 90;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            finalrotation -= 90;
        }
        Quaternion targetrotation = Quaternion.Euler(0, finalrotation, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation, turningspeed * Time.deltaTime);
    }
}
