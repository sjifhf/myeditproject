using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("顏色設定")]
    public Color normalColor = new Color(0.2f, 0.6f, 1f);
    public Color hoverColor = new Color(0.4f, 0.8f, 1f);
    public float colorFadeSpeed = 5f;

    [Header("縮放設定")]
    public float hoverScale = 1.1f;     // 放大倍率
    public float scaleSpeed = 5f;       // 放大速度

    private Image img;
    private Color targetColor;
    private Vector3 targetScale;
    private Vector3 originalScale;

void Start()
{
    img = GetComponent<Image>();
    img.color = normalColor;

    targetColor = normalColor; // <-- 新增這行，保證初始顏色正確

    originalScale = transform.localScale;
    targetScale = originalScale;
}


    void Update()
    {
        // 平滑漸變顏色
        img.color = Color.Lerp(img.color, targetColor, Time.deltaTime * colorFadeSpeed);

        // 平滑縮放
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetColor = hoverColor;
        targetScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetColor = normalColor;
        targetScale = originalScale;
    }
}
