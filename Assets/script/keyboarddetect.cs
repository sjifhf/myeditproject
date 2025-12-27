using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboarddetect : MonoBehaviour
{
    public Image W;
    public Image A;
    public Image S;
    public Image D;
    public Image Space;
    public Color basic = Color.white;
    public Color pressed = Color.gray;
    public float revertDelay = 0.2f; // 顏色維持時間

    private Coroutine wCoroutine, aCoroutine, sCoroutine, dCoroutine,SpaceCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Space.color = pressed;
        }
        else Space.color = basic;

        if (Input.GetKeyDown(KeyCode.W))
        {
            W.color = pressed;
        }
        else W.color = basic;

        if (Input.GetKeyDown(KeyCode.A))
        {
            A.color = pressed;
        }
        else A.color = basic;

        if (Input.GetKeyDown(KeyCode.S))
        {
            S.color = pressed;
        }
        else S.color = basic;

        if (Input.GetKeyDown(KeyCode.D))
        {
            D.color = pressed;
        }
        else D.color = basic;
    }*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartPress(ref wCoroutine, W);
        if (Input.GetKeyDown(KeyCode.A))
            StartPress(ref aCoroutine, A);
        if (Input.GetKeyDown(KeyCode.E))
            StartPress(ref sCoroutine, S);
        if (Input.GetKeyDown(KeyCode.D))
            StartPress(ref dCoroutine, D);
        if (Input.GetKeyDown(KeyCode.Space))
            StartPress(ref SpaceCoroutine, Space);
    }

    void StartPress(ref Coroutine coroutine, Image img)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(PressEffect(img));
    }

    IEnumerator PressEffect(Image img)
    {
        img.color = pressed;
        yield return new WaitForSeconds(revertDelay);
        img.color = basic;
    }
}
