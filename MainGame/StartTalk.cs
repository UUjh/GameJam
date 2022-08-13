using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StartTalk : MonoBehaviour
{
    public TextMeshProUGUI text;
    string[] texts = new string[4];

    

    void Start()
    {
        texts[0] = "�ȳ��ϼ���. �αٵα� �����뿡 ���� �������� ȯ���մϴ�.\n�������� ª�� �ð� �ȿ� �ϼ��� ������ ����� ���� ��ǥ�Դϴ�.";
        texts[1] = "�ϼ��� ������ ���� �� �����ϴ� ������ ������ ���� ����� ������.\n������ �� �÷����Դϴ�. ��������� ����?\n������ �ذ��ϱ� ���� ������ �ʼ���";
        texts[2] = "�׷��� �������� ���� ������ ����µ� ������ �� ���Դϴ�.����ִ� ������ ����� ���� ���������� ������ ������!";
        texts[3] = "�����е��� �ǽ��� ���ϴ�.";
        StartCoroutine(typing());
        TalkEnd();
    }

    IEnumerator typing()
    {

        yield return new WaitForSeconds(2f);
        for (int i = 0; i < texts.Length; i++)
        {
            for (int j = 0; j <= texts[i].Length; j++)
            {
                text.text = texts[i].Substring(0, j);
                yield return new WaitForSeconds(0.07f);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
    //
    void TalkEnd()
    {
        this.gameObject.SetActive(false);
    }
}
