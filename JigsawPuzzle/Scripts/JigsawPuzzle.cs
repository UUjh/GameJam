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
        JigsawPuzzle_Popup.instance.OpenPopUp("WARNING", "그래픽 수정 필요. \n\n" +
       "제한시간 내에 퍼즐을 맞춰주세요.\n\n 제한시간: 2분",
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
            timerText.text = "남은 시간 : " + (int)setTime + "초";
        }
        if (setTime < 30f)
        {
            timerText.text = "<color=orange>" + "남은 시간 : " + (int)setTime + "초" + "</color>";
        }
        if (setTime < 20f)
        {
            timerText.text = "<color=red>" + "남은 시간 : " + (int)setTime + "초" + "</color>";
        }
        if (setTime <= 0)
        {
            setTime = 0;
            Debug.Log("퍼즐 완료");
            JigsawPuzzle_Popup.instance.OpenPopUp("Time Out", "마감 기한을 지키지 못 했습니다.\n얻은 그래픽 점수 없음",
            () =>
            {
                Debug.Log("OKClick");
                SceneManager.LoadScene("MainGame");
            },
            () =>
            {
                Debug.Log("OKCancel");
            });
            Debug.Log("제한시간 끝");
        }


        // 퍼즐 완성 판정
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
            Debug.Log("10점");
        }
        if (timeSet < 60f && timeSet >= 40f)
        {
            PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") + 7);
            score = 7;
            Debug.Log("7점");

        }
        if (timeSet < 40f && timeSet >= 20f)
        {
            PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") + 5);
            score = 5;
            Debug.Log("5점");

        }
        if (timeSet < 20f)
        {
            PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") + 2);
            score = 2;
            Debug.Log("2점");

        }

        Debug.Log("퍼즐 완료");
        JigsawPuzzle_Popup.instance.OpenPopUp("그래픽 수정 완료! \n", "얻은 그래픽 점수 : " + score,
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
