using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;

public class countdown : MonoBehaviour
{
    public int countdownTime = 5;          // 倒數秒數
    public GameObject teachUI;             // 教學介面（可以控制是否顯示）
    public TMP_Text countdownText;         // 顯示倒數的文字元件
    public Button teachUI_closedButton;    // 教學介面的關閉按鈕

    void OnEnable()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString(); // 顯示倒數
            yield return new WaitForSeconds(1f);           // 每秒減一次
            countdownTime--;
        }

        // ✅ 倒數結束時隱藏文字
        countdownText.text = "";
        teachUI_closedButton.interactable = true; // 啟用關閉按鈕
        teachUI_closedButton.IsActive();

    }
}
