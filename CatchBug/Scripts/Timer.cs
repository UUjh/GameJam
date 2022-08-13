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
            //textTimer.text = "남은 시간 : " + (int)sec + "초";
        }
        if (setTime < 15f)
        {
            textTimer.text = "<color=red>" + "남은 시간 : " + (int)setTime + "초" + "</color>";
        }
        if (setTime <= 0)
        {
            Debug.Log("시간 끝");
        }
    }
}
