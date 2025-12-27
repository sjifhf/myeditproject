using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class trigger_teachUI : MonoBehaviour
{
    public GameObject hintUI;
    public Button button;
    private bool canTrigger = true;

    public VideoPlayer videoPlayer;

    public GameObject RawImage;
    // Start is called before the first frame update
    void Start()
    {
        hintUI.SetActive(false); // 一開始隱藏
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // 如果碰到 teachUI_point 物件，則觸發
        if (other.CompareTag("teachUI_point"))
        {
            if (canTrigger)
            {
                hintUI.SetActive(true);
                button.interactable = true;
                canTrigger = false;
                RawImage.SetActive(true);
                videoPlayer.enabled = true;
                videoPlayer.Play();
                
            }
        }
    }
}
