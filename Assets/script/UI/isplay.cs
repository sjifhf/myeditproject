using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class isplay : MonoBehaviour
{
    public VideoPlayer traggateVideoplayer;
    public GameObject teachUI_rawimage;
    public GameObject traggteObject;//要偵測的物件
    // Start is called before the first frame update
    void Start()
    {
        teachUI_rawimage.SetActive(true);
        traggateVideoplayer.enabled = true;
        Debug.Log(traggateVideoplayer.texture.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
