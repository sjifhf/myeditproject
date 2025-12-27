using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getitemvisible : MonoBehaviour
{
    private getitem jump;
    public int jumpi = 1;
    public Vector3[] itemplace;
    public int itemnumber, save, load; //��o����,�s���U��m,�^�ǭ��m
    public GameObject jumpitem;
    public GameObject jumpbuff; //�O�_��o���~
    // Start is called before the first frame update
    void Start()
    {
        itemplace = new Vector3[6];
        //itemplace[0] = new Vector3(141, -44, 0);
        itemplace[0] = new Vector3(163, -44, 0);
        itemplace[1] = new Vector3(227, -44, 0);
        itemplace[2] = new Vector3(290, -44, 0);
        itemplace[3] = new Vector3(355 - 44, 0);
        itemplace[4] = new Vector3(420, -44, 0);
        itemplace[5] = new Vector3(483, -44, 0);
        jump = jumpbuff.GetComponent<getitem>();
        itemnumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //��o���~���
        if (jump.activejump == 0 && jumpi == 1 && itemnumber < 6)
        {
            jumpitem.SetActive(true);
            jumpitem.transform.position = itemplace[itemnumber];
            jumpi = itemnumber;
            itemnumber++;
            load = 1;
            jumpitem.transform.SetParent(transform);

            if (transform.position.y >= 65)
            {
                jumpitem.transform.position += new Vector3(0, 300, 0);
            }
        }
        //..........


        //���~����
        if (jumpi != 1 && jump.activejump == 1)
        {
            save = itemnumber;
            itemnumber = jumpi;
        }


        //���~�ɤW�Ŧ�ᶶ�Ƿ���
        if (load == 1)
        {
            if (save != 0)
            {
                itemnumber = save;
            }
            save = 0;
        }
    }
}
