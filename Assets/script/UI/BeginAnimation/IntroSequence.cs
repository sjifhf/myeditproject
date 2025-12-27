using UnityEngine;
using System.Collections;

public class IntroSequence : MonoBehaviour
{
    public EyeOpenUI eyeUI;
    public IntroLookAround lookScript;
    public MonoBehaviour playerControl; // 你的 PlayerMovement

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        playerControl.enabled = false;

        yield return eyeUI.OpenEyes();
        yield return lookScript.LookAround();

        playerControl.enabled = true;
    }
}
