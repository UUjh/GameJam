using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEvent1 : MonoBehaviour
{
    public TMP_Text text;
    string[] texts = new string[2];
    public Button btn0;
    public Button btn1;
    public Button btn2;

    public DataManager dataManger;




    void Start()
    {
        texts[0] = "기획자님, 제가 고민을 해보았는데요...";
        texts[1] = "추가되는 콘텐츠의 재미가 진부해 보여서.. \n" +
            "제가 생각해본 방안으로 수정해보는 건 어떨까요?";
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
        // 창의성 +5, 기획자 피로도 +15
        Debug.Log("게임 재미+=5, 기획자 피로도 += 15");
        dataManger.fun += 5;
        EventTextEnd0();

    }

    public void ButtonEvnet1()
    {
        // 게임 재미 -5, 창의성 +10, 프로그래머 성실도 -10, 기획자 성실도 -10
        EventTextEnd0();

    }

    public void ButtonEvent2()
    {
        // 창의성 -10, 기획자 성실도 +15, 프로그래머 성실도 +15
        EventTextEnd0();

    }

    void EventTextEnd0()
    {
        btn0.gameObject.SetActive(false);
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
    }
}
