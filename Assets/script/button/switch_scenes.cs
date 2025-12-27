using UnityEngine;
using UnityEngine.SceneManagement; // 加入這行

public class switch_Scenes : MonoBehaviour
{
    // 在 Inspector 設定要切換的場景名稱
    public string sceneName;

    // 這個方法可以被按鈕呼叫
    public void SwitchScene()
    {
        // 載入指定場景
        SceneManager.LoadScene(sceneName);
    }
}
