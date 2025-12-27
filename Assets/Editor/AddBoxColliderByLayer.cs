using UnityEngine;
using UnityEditor;

public class AddBoxColliderByLayer
{
    [MenuItem("Tools/Add BoxCollider To Layer")]
    static void AddCollider()
    {
        // ⚠️ 改成你要的 Layer 名稱
        string targetLayerName = "collider";

        int targetLayer = LayerMask.NameToLayer(targetLayerName);
        if (targetLayer == -1)
        {
            Debug.LogError("找不到 Layer: " + targetLayerName);
            return;
        }

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        int count = 0;

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == targetLayer)
            {
                // 已經有 Collider 就跳過
                if (obj.GetComponent<Collider>() != null)
                    continue;

                // 只對有 Mesh 的物件加
                if (obj.GetComponent<MeshRenderer>() != null)
                {
                    obj.AddComponent<BoxCollider>();
                    count++;
                }
            }
        }

        Debug.Log($"完成，新增 BoxCollider 數量：{count}");
    }
}
