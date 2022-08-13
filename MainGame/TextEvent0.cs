using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEvent0 : MonoBehaviour
{
    public TMP_Text text;
    string[] texts = new string[2];
    public Button btn0;
    public Button btn1;
    public Button btn2;

    public DataManager dataManger;




    void Start()
    {
        texts[0] = "��ȹ�ڴ�, ���� ����� �غ��Ҵµ���...";
        texts[1] = "���� �ȿ� �������� ���� ������ ���̴��� \n" +
            "���� �����غ� ������� �����غ��� �� ����?";
        StartCoroutine(typing());
        EventTextEnd0();

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
        Destroy(text);
        btn0.gameObject.SetActive(true);
        btn1.gameObject.SetActive(true);
        btn2.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonEvent0()
    {
        // ���� ��� + 5, ��ȹ�� �Ƿε� + 15
        Debug.Log("���� ���+=5, ��ȹ�� �Ƿε� += 15");
        dataManger.fun += 5;
        EventTextEnd0();

    }

    public void ButtonEvnet1()
    {
        // ���α׷��� ���ǵ� -18, ��ȹ�� �Ƿε� -28
        EventTextEnd0();

    }

    public void ButtonEvent2()
    {
        // ��ȹ���� ���ǵ� = 30, ���α׷����� ���ǵ� + 30, ��ȹ���� �Ƿε� + 10, ���α׷����� �Ƿε� +10
        EventTextEnd0();

    }

    void EventTextEnd0()
    {
        btn0.gameObject.SetActive(false);
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
    }
}
