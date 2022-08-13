using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugMaker : MonoBehaviour
{
    public GameObject bugPrefab;
    public Transform bugRoot;

    public DataManager dataManager;

    public float spawnTime = 5.0f;
    public int spawnCount = 10;

    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI timerText;

    private int score;
    float setTime = 10000;
    float sec;

    int getFun;

    AudioSource bugDead;

    private void Awake()
    {

        CatchBug_Popup.instance.OpenPopUp("어...?", "버그가 나타났다. \n" +
            "60초 동안 화면에 기어다니는 버그를 \n최대한 많이 잡아내자.",
           () =>
           {
               Debug.Log("OKClick");
               InvokeRepeating("Spawn", 0.0f, spawnTime);
               setTime = 60f;
           },
           () =>
           {
               Debug.Log("OKCancel");
           });
    }

    void Start()
    {
        bugDead = GetComponent<AudioSource>();
        getFun = 0;
    }


    public void Update()
    {
        setTime -= Time.deltaTime;

        if (setTime >= 15f)
        {
            sec = setTime % 60;
            timerText.text = "남은 시간 : " + (int)sec + "초";
        }
        if (setTime < 15f)
        {
            timerText.text = "<color=red>" + "남은 시간 : " + (int)setTime + "초" + "</color>";
        }
        if (setTime <= 0)
        {
            Debug.Log("시간 끝");

            CatchBugEnd();
            CancelInvoke();

        }
    }


    void Spawn()
    {
        Vector3 pos = new Vector3();

        float screenHalfHeight = Camera.main.orthographicSize;
        float screenHalfWidth = screenHalfHeight * Camera.main.aspect;
        float angle = 0.0f;

        for (int i = 0; i< spawnCount; i++)
        {
            switch (i % 4)
            {
                // 왼쪽에서 생성
                case 0:
                    pos.x = -screenHalfWidth;
                    pos.y = Random.Range(-screenHalfHeight, screenHalfHeight);
                    angle = -90.0f;
                    break;
                // 오른쪽에서 생성
                case 1:
                    pos.x = screenHalfWidth;
                    pos.y = Random.Range(-screenHalfHeight, screenHalfHeight);
                    angle = 90.0f;
                    break;
                // 위쪽에서 생성
                case 2:
                    pos.x = Random.Range(-screenHalfWidth, screenHalfWidth);
                    pos.y = screenHalfHeight;
                    angle = 180.0f;
                    break;
                // 아래쪽에서 생성
                case 3:
                    pos.x = Random.Range(-screenHalfWidth, screenHalfWidth);
                    pos.y = -screenHalfHeight;
                    angle = 0.0f;
                    break;
            }

            GameObject gameObj = Instantiate(bugPrefab, bugRoot);

            gameObj.transform.position = pos;
            gameObj.transform.Rotate(0.0f, 0.0f, angle);

        }
    }

    public void OnBugDead()
    {
        Debug.Log("벌레 죽음");
        bugDead.Play();
        score++;
        scoreText.text = "잡은 버그 : " + score + "개";
    }

    public void CatchBugEnd()
    {
        setTime = 0;
        if (0 <= score && score <= 20)
        {
            getFun = 0;
        }
        if ( 20 < score && score <= 30)
        {
            getFun = 2;
            dataManager.fun += 2;
        }
        if (31 < score && score <= 40)
        {
            getFun = 5;
            dataManager.fun += 5;
        }
        if(41 < score && score < 50)
        {
            getFun = 7;
            dataManager.fun += 7;
        }
        if (score >= 50)
        {
            getFun = 10;
            dataManager.fun += 10;
        }
        CatchBug_Popup.instance.OpenPopUp("Time Out", "잡은 버그 : " + score + "개\n" + "얻은 재미 스탯 : " + getFun,
        () =>
        {
            Debug.Log("OKClick");
            SceneManager.LoadScene("MainGame");
        },
        () =>
        {
            Debug.Log("OKCancel");
        });
    }
    
}

