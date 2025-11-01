using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public Button targetButton;  // 指定要控制的按鈕
    public float delayTime = 5f; // 延遲秒數


    private void Start()
    {
        if (targetButton != null)
        {
            // 一開始禁止點擊

            // 改變按鈕顏色為灰色
            ColorBlock colors = targetButton.colors;
            colors.disabledColor = new Color(0.5f, 0.5f, 0.5f, 1f); // 灰色
            targetButton.colors = colors;
        }
    }

    private void Update()
    {
        if (delayTime > 0)
        {
            delayTime -= Time.deltaTime;
        }

        else
        {

            if (targetButton != null)
            {
                targetButton.interactable = true;
                // 改成白色
                ColorBlock colors = targetButton.colors;
                colors.normalColor = Color.white;
                targetButton.colors = colors;
            }
        }
    }
}
