using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

public class Esc_continue : MonoBehaviour
{
    public GameObject escUI_panel;

    // 如果你之前有暫停影片，需要記錄
    private List<VideoPlayer> pausedVideos = new List<VideoPlayer>();

    public void ContinueTheGame()
    {
        // 關閉 ESC 面板
        if (escUI_panel != null)
        {
            escUI_panel.SetActive(false);
            Debug.Log("escUI_panel active: " + escUI_panel.activeSelf);
        }

        // 回復遊戲時間
        Time.timeScale = 1f;

        // 讓暫停的影片繼續播放
        foreach (var v in pausedVideos)
        {
            if(v != null)
                v.Play();
        }
    }

    // 你可以在這裡寫方法去暫停影片並存入 pausedVideos
    public void PauseVideos(VideoPlayer[] allVideos)
    {
        pausedVideos.Clear();
        foreach (var v in allVideos)
        {
            if (v.isPlaying)
            {
                v.Pause();
                pausedVideos.Add(v);
            }
        }
    }
}
