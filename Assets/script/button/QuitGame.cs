using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // 這個方法可以在按鈕 OnClick() 事件中綁定
    public void Quit()
    {
        Debug.Log("遊戲即將關閉");
        Application.Quit();

        // 在編輯器中測試用
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
