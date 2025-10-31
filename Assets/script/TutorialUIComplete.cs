using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System.Collections;

public class TutorialUIComplete : MonoBehaviour
{
    [Header("UI / Video")]
    public GameObject tutorialPanel;    // Panel_Tutorial (半透明背景)
    public RawImage videoRawImage;      // RawImage 顯示影片
    public RenderTexture renderTexture; // 可在 Project 建，也可留空由腳本自動建立
    public VideoPlayer videoPlayer;     // VideoPlayer（若沒拖，腳本會新增到同一物件）
    
    [Header("Countdown / Button")]
    public TMP_Text countdownText;      // 顯示倒數文字（5 4 3 2 1 -> 跳過）
    public Button skipButton;           // 跳過按鈕（初始不可按）
    public int countdownSeconds = 5;    // 倒數秒數

    [Header("Player Control")]
    public MonoBehaviour playerController; // 指你的移動腳本（例如 PlayerController），腳本會 enable/disable

    private bool isPlaying = false;

    void Awake()
    {
        // 基本檢查
        if (tutorialPanel == null) Debug.LogWarning("TutorialUIComplete: tutorialPanel 未設定（拖 Panel_Tutorial）");
        if (videoRawImage == null) Debug.LogWarning("TutorialUIComplete: videoRawImage 未設定（拖 RawImage）");
        if (countdownText == null) Debug.LogWarning("TutorialUIComplete: countdownText 未設定");
        if (skipButton == null) Debug.LogWarning("TutorialUIComplete: skipButton 未設定");

        // 如果 VideoPlayer 不存在，就加一個（方便快速設置）
        if (videoPlayer == null)
        {
            videoPlayer = gameObject.GetComponent<VideoPlayer>();
            if (videoPlayer == null)
            {
                videoPlayer = gameObject.AddComponent<VideoPlayer>();
            }
        }

        // RenderTexture：若沒在 Inspector 指定，建立一個預設大小
        if (renderTexture == null)
        {
            renderTexture = new RenderTexture(1280, 720, 0);
            renderTexture.name = "TutorialVideoRT_Runtime";
        }

        // RawImage 指向 RenderTexture
        if (videoRawImage != null)
        {
            videoRawImage.texture = renderTexture;
        }

        // 設定 VideoPlayer 輸出到 RenderTexture
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.playOnAwake = false;

        // Button 初始不可按（可由 Inspector 直接取消 Interactable；這裡也保險性設定）
        if (skipButton != null)
        {
            skipButton.interactable = false;
            skipButton.onClick.RemoveAllListeners();
            skipButton.onClick.AddListener(OnSkipButton);
        }
    }

    void Start()
    {
        // 顯示 Panel（若你想預先隱藏，請改成 SetActive(false) 並在需要時呼叫 ShowTutorial()）
        if (tutorialPanel != null) tutorialPanel.SetActive(true);

        // 禁止玩家移動
        if (playerController != null) playerController.enabled = false;

        // 播放影片並開始倒數
        PlayAndCountdown();
    }

    public void PlayAndCountdown()
    {
        if (videoPlayer != null && !isPlaying)
        {
            videoPlayer.Play();
            isPlaying = true;
            StartCoroutine(CountdownRoutine());
        }
    }

    private IEnumerator CountdownRoutine()
    {
        int t = Mathf.Max(1, countdownSeconds);
        while (t > 0)
        {
            if (countdownText != null) countdownText.text = t.ToString();
            yield return new WaitForSeconds(1f);
            t--;
        }

        if (countdownText != null) countdownText.text = "";
        if (skipButton != null) skipButton.interactable = true;
    }

    // 被按下跳過或想結束教學時呼叫
    public void OnSkipButton()
    {
        CloseTutorial();
    }

    public void CloseTutorial()
    {
        // 停影片
        if (videoPlayer != null && videoPlayer.isPlaying) videoPlayer.Stop();
        isPlaying = false;

        // 隱藏 UI
        if (tutorialPanel != null) tutorialPanel.SetActive(false);

        // 恢復玩家控制
        if (playerController != null) playerController.enabled = true;
    }

    // 若你想要當影片自動播放結束也自動關閉（可選）
    private void OnEnable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    private void OnDisable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // 影片播完也可以自動開放跳過或自動關閉
        // 這裡我們不自動關閉，僅確保玩家可跳過（若想自動關閉，把 CloseTutorial() 放開）
        if (skipButton != null) skipButton.interactable = true;
        if (countdownText != null) countdownText.text = "跳過";
    }
}
