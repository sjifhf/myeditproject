using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EyeOpenUI : MonoBehaviour
{
    public RectTransform top;
    public RectTransform bottom;
    public float openDuration = 1.5f;

    public IEnumerator OpenEyes()
    {
        float t = 0f;
        Vector2 topStart = top.anchoredPosition;
        Vector2 botStart = bottom.anchoredPosition;

        Vector2 topEnd = topStart + Vector2.up * top.rect.height;
        Vector2 botEnd = botStart + Vector2.down * bottom.rect.height;

        while (t < openDuration)
        {
            float lerp = t / openDuration;
            top.anchoredPosition = Vector2.Lerp(topStart, topEnd, lerp);
            bottom.anchoredPosition = Vector2.Lerp(botStart, botEnd, lerp);
            t += Time.deltaTime;
            yield return null;
        }

        top.gameObject.SetActive(false);
        bottom.gameObject.SetActive(false);
    }
}
