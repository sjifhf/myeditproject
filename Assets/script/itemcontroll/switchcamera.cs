using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcamera : MonoBehaviour
{
    private switchitemusing positionplace; //������ܮئb���Ӧ�m
    private itemsortappear updown;
    public GameObject player,freecam,choosequare,playercam,itemsort;
    public float timeDelay = 10f;
    // Start is called before the first frame update
    void Start()
    {
        positionplace = choosequare.GetComponent<switchitemusing>();
        updown = itemsort.GetComponent<itemsortappear>();
    }

    // Update is called once per frame
    void Update()
    {
        if(positionplace.switchitem % 7 == 0 &&@Input.GetKeyDown(KeyCode.DownArrow) && positionplace.heightfollow)
        {
            StartCoroutine(Camerausing());
        }
    }

    IEnumerator Camerausing()
    {
        updown.downactive = true;
        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<rotationchanging>().enabled = false;
        freecam.SetActive(true);
        playercam.SetActive(false);
        yield return new WaitForSeconds(timeDelay);
        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<rotationchanging>().enabled = true;
        freecam.transform.position = player.transform.position + new Vector3(8, 8, -8);
        freecam.transform.LookAt(player.transform);
        freecam.SetActive(false);
        playercam.SetActive(true);
    }
}
