using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teachUI_close : MonoBehaviour
{
    public GameObject teachUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ⚠️ 方法名稱要改成大寫 OnClick，或在 Inspector 手動綁定
    public void CloseTeachUI()
    {
        teachUI.SetActive(false);
    }
}

