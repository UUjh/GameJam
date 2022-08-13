using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Stats : MonoBehaviour
{
    TMP_Text text;
    public DataManager dataManager;

    private void Start()
    {
        
    }

    public void Excellent()
    {
        dataManager.fun += 10;
        dataManager.creativity += 10;
        dataManager.graphic += 10;
        dataManager.sound += 10;

        Debug.Log("�ֻ���");
    }

    public void Good()
    {
        dataManager.fun += 5;
        dataManager.creativity += 5;
        dataManager.graphic += 5;
        dataManager.sound += 5;

        Debug.Log("����");
    }

    public void Nomal()
    {
    }

    public void Bad()
    {
        dataManager.fatigue += 100;
        Debug.Log("�ϵ��");
    }

    public void BasicMember()
    {
        dataManager.fun += 5;
        dataManager.creativity += 5;
        dataManager.graphic += 5;
        dataManager.sound += 5;
        Debug.Log("���۸��");
    }
}
