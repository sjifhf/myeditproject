using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public Button targetButton;  // 指定要控制的按鈕
    public float delayTime = 5f; // 延遲秒數
    public GameObject teachUI;             // 教學介面（可以控制是否顯示）

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.interactable = false; // 初始設為不可點擊
        }
    }

    public void cloeseTeachUI()
    {
        teachUI.SetActive(false);
    }

    private void Update()
    {
        if (teachUI.activeSelf == true)
        {
            if (delayTime > 0) //倒數階段
            {
                delayTime -= Time.deltaTime;
            }

            else //倒數結束
            {
                teachUI.SetActive(true);
                targetButton.interactable = true; // 允許點擊
            }
        }
    }
}
