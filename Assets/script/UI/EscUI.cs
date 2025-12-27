using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

public class EscUI : MonoBehaviour
{
    public GameObject escUI_panel;

    bool isEscUIOpen = false;

    VideoPlayer[] allVideos;
    List<VideoPlayer> pausedVideos = new List<VideoPlayer>();

    void Start()
    {
        escUI_panel.SetActive(false);
        Time.timeScale = 1f;
        allVideos = FindObjectsOfType<VideoPlayer>();
    }

    void Update()
    {
        isEscUIOpen = escUI_panel.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEscUIOpen = !isEscUIOpen;
            escUI_panel.SetActive(isEscUIOpen);
            if (isEscUIOpen)
                PauseGame();
            else
                ResumeGame();

        }

    }

    void PauseGame()
    {
        Time.timeScale = 0f;

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
    public void ContinueGame()
    {
        if (isEscUIOpen)
        {
            isEscUIOpen = false;
            escUI_panel.SetActive(false);
            ResumeGame();
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;

        foreach (var v in pausedVideos)
        {
            v.Play();
        }
    }
}
