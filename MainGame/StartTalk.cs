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
        texts[0] = "안녕하세요. 두근두근 게임잼에 오신 여러분을 환영합니다.\n게임잼은 짧은 시간 안에 완성된 게임을 만드는 것이 목표입니다.";
        texts[1] = "완성된 게임은 게임 내 존재하는 게임의 스탯을 높게 만드는 것이죠.\n개발은 팀 플레이입니다. 팀원들과의 소통?\n문제를 해결하기 위한 협업은 필수죠";
        texts[2] = "그러한 과정들은 좋은 게임을 만드는데 도움이 될 것입니다.재미있는 게임을 만들기 위해 전략적으로 접근해 보세요!";
        texts[3] = "여러분들의 건승을 빕니다.";
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
