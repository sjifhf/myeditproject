using UnityEngine;
using System.Collections;

public class IntroLookAround : MonoBehaviour
{
    public Transform cameraTransform;
    public float lookSpeed = 2f;

    public IEnumerator LookAround()
    {
        yield return LookTo(new Vector3(0, -30, 0)); // 左
        yield return new WaitForSeconds(0.3f);

        yield return LookTo(new Vector3(0, 30, 0));  // 右
        yield return new WaitForSeconds(0.3f);

        yield return LookTo(new Vector3(-10, 0, 0)); // 上
        yield return LookTo(Vector3.zero);           // 回正
    }

    IEnumerator LookTo(Vector3 targetEuler)
    {
        Quaternion start = cameraTransform.localRotation;
        Quaternion end = Quaternion.Euler(targetEuler);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * lookSpeed;
            cameraTransform.localRotation = Quaternion.Slerp(start, end, t);
            yield return null;
        }
    }
}
