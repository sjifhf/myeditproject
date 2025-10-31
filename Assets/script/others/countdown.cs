using UnityEngine;
using TMPro;
using System.Collections;

public class countdown : MonoBehaviour
{
    public int countdownTime = 5;          // 倒數秒數
    public GameObject teachUI;             // 教學介面（可以控制是否顯示）
    public TMP_Text countdownText;         // 顯示倒數的文字元件

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
    }
}
