using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_teachUI : MonoBehaviour
{
    public GameObject hintUI;
    public GameObject hideButton;
    private bool canTrigger = true;
    // Start is called before the first frame update
    void Start()
    {
        if (hintUI != null)
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
            if (hintUI != null)
            {
                hintUI.SetActive(true); // 玩家進入 → 顯示提示
            }
        }
    }
        // 供 UI Button 指向：按下後隱藏提示，並防止再次觸發
    public void OnHideButtonPressed()
    {
        if (hintUI != null)
            hintUI.SetActive(false);

        canTrigger = false;

        // 停用此 Trigger（避免再次顯示）
        var col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // 停用此 component（可選）
        this.enabled = false;
    }
}
