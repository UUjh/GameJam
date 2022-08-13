using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class JigsawPuzzle : MonoBehaviour
{
    public DataManager dataManager;
    public AudioMixer audioMixer;

    public GameObject[] pieces;
    float audioGameSound;
    float setTime = 1000;
    public TMPro.TextMeshProUGUI timerText;
    public int ClearCheck;
    //bool clear = false;
    public float timeSet;
    int score;

    void Start()
    {
        timeSet = 0;
        audioGameSound = PlayerPrefs.GetFloat("BGM");
        audioMixer.SetFloat("BGM", -80);
        audioMixer.SetFloat("SoundGameBgm", audioGameSound);
        ClearCheck = 0;
        //clear = false;
        JigsawPuzzle_Popup.instance.OpenPopUp("WARNING", "�׷��� ���� �ʿ�. \n\n" +
       "���ѽð� ���� ������ �����ּ���.\n\n ���ѽð�: 2��",
       () =>
       {
           Debug.Log("OKClick");
           setTime = 120f;
       },
       () =>
       {
           Debug.Log("OKCancel");
       });
    }

    // Update is called once per frame
    void Update()
    {
        setTime -= Time.deltaTime;
        

        if (setTime >= 30f)
        {
            //sec = setTime % 60;
            timerText.text = "���� �ð� : " + (int)setTime + "��";
        }
        if (setTime < 30f)
        {
            timerText.text = "<color=orange>" + "���� �ð� : " + (int)setTime + "��" + "</color>";
        }
        if (setTime < 20f)
        {
            timerText.text = "<color=red>" + "���� �ð� : " + (int)setTime + "��" + "</color>";
        }
        if (setTime <= 0)
        {
            setTime = 0;
            Debug.Log("���� �Ϸ�");
            JigsawPuzzle_Popup.instance.OpenPopUp("Time Out", "���� ������ ��Ű�� �� �߽��ϴ�.\n���� �׷��� ���� ����",
            () =>
            {
                Debug.Log("OKClick");
                SceneManager.LoadScene("MainGame");
            },
            () =>
            {
                Debug.Log("OKCancel");
            });
            Debug.Log("���ѽð� ��");
        }


        // ���� �ϼ� ����
        if (pieces[0].transform.position == pieces[0].GetComponent<PiecesScripts>().rightPosition
        && pieces[1].transform.position == pieces[1].GetComponent<PiecesScripts>().rightPosition
        && pieces[2].transform.position == pieces[2].GetComponent<PiecesScripts>().rightPosition
        && pieces[3].transform.position == pieces[3].GetComponent<PiecesScripts>().rightPosition
        && pieces[4].transform.position == pieces[4].GetComponent<PiecesScripts>().rightPosition
        && pieces[5].transform.position == pieces[5].GetComponent<PiecesScripts>().rightPosition
        && pieces[6].transform.position == pieces[6].GetComponent<PiecesScripts>().rightPosition
        && pieces[7].transform.position == pieces[7].GetComponent<PiecesScripts>().rightPosition
        && pieces[8].transform.position == pieces[8].GetComponent<PiecesScripts>().rightPosition
        && pieces[9].transform.position == pieces[9].GetComponent<PiecesScripts>().rightPosition
        && pieces[10].transform.position == pieces[10].GetComponent<PiecesScripts>().rightPosition
        && pieces[11].transform.position == pieces[11].GetComponent<PiecesScripts>().rightPosition
        && pieces[12].transform.position == pieces[12].GetComponent<PiecesScripts>().rightPosition
        && pieces[13].transform.position == pieces[13].GetComponent<PiecesScripts>().rightPosition
        && pieces[14].transform.position == pieces[14].GetComponent<PiecesScripts>().rightPosition
        && pieces[15].transform.position == pieces[15].GetComponent<PiecesScripts>().rightPosition
        && pieces[16].transform.position == pieces[16].GetComponent<PiecesScripts>().rightPosition
        && pieces[17].transform.position == pieces[17].GetComponent<PiecesScripts>().rightPosition
        && pieces[18].transform.position == pieces[18].GetComponent<PiecesScripts>().rightPosition
        && pieces[19].transform.position == pieces[19].GetComponent<PiecesScripts>().rightPosition
        && ClearCheck == 0
        )
        {
            //PuzzleClear(setTime);
            PuzzleClear();
        }
    }
    public void PuzzleClear()
    {
        ClearCheck = 1;
        timeSet = setTime;
        //clear = true;
        //setTime -= 0;

        //this.setTime = setTime1;
        if (timeSet >= 60f)
        {
            PlayerPrefs.SetInt("Graphic",PlayerPrefs.GetInt("Graphic") + 10);
            score = 10;
            Debug.Log("10��");
        }
        if (timeSet < 60f && timeSet >= 40f)
        {
            PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") + 7);
            score = 7;
            Debug.Log("7��");

        }
        if (timeSet < 40f && timeSet >= 20f)
        {
            PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") + 5);
            score = 5;
            Debug.Log("5��");

        }
        if (timeSet < 20f)
        {
            PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") + 2);
            score = 2;
            Debug.Log("2��");

        }

        Debug.Log("���� �Ϸ�");
        JigsawPuzzle_Popup.instance.OpenPopUp("�׷��� ���� �Ϸ�! \n", "���� �׷��� ���� : " + score,
        () =>
        {
            Debug.Log("OKClick");
            audioMixer.SetFloat("SoundGameBgm", -80);
            audioMixer.SetFloat("BGM", audioGameSound);
            SceneManager.LoadScene("MainGame");
        },
        () =>
        {
            Debug.Log("OKCancel");
        });
    }
}
