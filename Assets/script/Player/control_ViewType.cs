using UnityEngine;

public class Control_ViewType : MonoBehaviour
{
    [Header("Movement")]
    public PlayerMovement_3D playerMovement_3D;
    public PlayerMovement_2D playerMovement_2D;

    [Header("Rotation / Camera")]
    public rotationchanging rotationScript; // 2D 轉向
    public MouseLook mouseLook;              // 3D 滑鼠視角

    public enum ViewType { View2D, View3D }
    public ViewType currentView = ViewType.View3D;

    void Start()
    {
        SwitchTo3D(); // 預設 3D
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentView == ViewType.View3D)
                SwitchTo2D();
            else
                SwitchTo3D();
        }
    }

    // ===== 切換函式 =====

    void SwitchTo2D()
    {
        currentView = ViewType.View2D;

        playerMovement_3D.enabled = false;
        playerMovement_2D.enabled = true;

        rotationScript.enabled = true;
        mouseLook.SetLookEnabled(false);

        Debug.Log("切換到 2D 視角");
    }

    void SwitchTo3D()
    {
        currentView = ViewType.View3D;

        playerMovement_3D.enabled = true;
        playerMovement_2D.enabled = false;

        rotationScript.enabled = false;
        mouseLook.SetLookEnabled(true);

        Debug.Log("切換到 3D 視角");
    }
}
