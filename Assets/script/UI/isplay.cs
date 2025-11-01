using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class isplay : MonoBehaviour
{
    public VideoPlayer traggateVideoplayer;
    public GameObject traggteObject;//要偵測的物件
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (traggteObject.activeSelf == true) //要偵測物件的狀態
        {
            traggateVideoplayer.Play();
        }
        else if(traggteObject.activeSelf == false)
        {
            traggateVideoplayer.Pause();
        }
    }
}
