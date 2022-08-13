using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshPro textTimer;

    float setTime = 60f;

    float sec;

    private void Awake()
    {
        textTimer = GameObject.Find(name: "Timer").GetComponent<TextMeshPro>();
    }


    void Update()
    {
        setTime -= Time.deltaTime;

        if (setTime >= 15f)
        {
            sec = setTime % 60;
            //textTimer.text = "���� �ð� : " + (int)sec + "��";
        }
        if (setTime < 15f)
        {
            textTimer.text = "<color=red>" + "���� �ð� : " + (int)setTime + "��" + "</color>";
        }
        if (setTime <= 0)
        {
            Debug.Log("�ð� ��");
        }
    }
}
