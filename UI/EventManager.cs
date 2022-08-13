using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class EventManager : MonoBehaviour
{
    public TMP_Dropdown mainDropdown;
    public TMP_Dropdown subDropdown;
    public Animator progress;
    public Animator progress2;
    public int clickCheck = 0;
    public DataManager dataManager;
    public Stats stats;
    public TextMeshProUGUI modeChange;
    public int clickCheck2 = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainTitleButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
    public void SettingTitleButtonClick()
    {
        SceneManager.LoadScene("Setting");
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void GameLoad()//안녕하세요
    {
        if(PlayerPrefs.GetInt("LoadDataCheck") == 1)
        {
            PopUpSystem.instance.OpenPopUp("불러오기", " 팀명 : " + PlayerPrefs.GetString("TeamName") + "\n 메인 장르 : " + PlayerPrefs.GetString("MainTema")
            + "\n 서브 장르 : " + PlayerPrefs.GetString("SubTema") + "\n 진척도 : " + PlayerPrefs.GetInt("ProGress") + "% \n\n 불러오시겠습니까?",
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
        else
        {

        }
    }
    public void ModeChange()
    {
        if(clickCheck2 == 0)
        {
            Screen.SetResolution(1024, 768, false);
            modeChange.text = "전체화면";
            clickCheck2 = 1;
        }
        else if(clickCheck2 == 1)
        {
            Screen.SetResolution(1980,1024,true);
            modeChange.text = "창모드";
            clickCheck2 = 0;
        }

    }
    public void NewGameButtonnClick()
    {
        if(PlayerPrefs.GetInt("LoadDataCheck")==1)
        {
            PopUpSystem.instance.OpenPopUp("<color=red>" + "경고!" + "</color>", "이미 존재하는 저장데이터가 있습니다. \n예를 누를 시 저장데이터는 초기화됩니다.\n\n 계속 진행하시겠습니까?", 
                ()=> { dataManager.DataReset(); SceneManager.LoadScene("NewGame"); }, ()=> { });
        }
        else
        {
            SceneManager.LoadScene("NewGame");
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SoundGameStart()
    {
        SceneManager.LoadScene("SoundGame");
    }
    public void MainTema()
    {

        for (int i = 1; i <= 11; i++)
        {
            if (mainDropdown.value == i)
            {
                Debug.Log(mainDropdown.options[mainDropdown.value].text);
                break;
            }
        }

    }
    public void SubTema()
    {
        for (int i = 1; i <= 36; i++)
        {
            if (subDropdown.value == i)
            {
                Debug.Log(subDropdown.options[subDropdown.value].text);
                break;
            }
        }
    }
    public void ProgressOpen()
    {
        progress.SetTrigger("ProgressOpen");
    }
    public void ProgressOpen2()
    {
       
        if(clickCheck == 0)
        {
           progress2.SetTrigger("ProgressOpen2");
            clickCheck = 1;
        }
        else if(clickCheck !=0)
        {
           progress2.SetTrigger("ProgressClose2");
           clickCheck=0;
        }
    }
    public void MixThema()
    {


        PlayerPrefs.SetString("MainTema", mainDropdown.options[mainDropdown.value].text);
        PlayerPrefs.SetString("SubTema", subDropdown.options[subDropdown.value].text);


        if (mainDropdown.value == 0 || subDropdown.value == 0)
        {
            Debug.Log("장르를 선택");
        }
        if (mainDropdown.value == 1)
        {
            //if (1 <= subDropdown.value && subDropdown.value <= 11)
            //{
            //    stats.Excellent();
            //}
            //if ( (37 <= subDropdown.value && subDropdown.value <= 39) ||  )
            //else if()
            switch (subDropdown.value)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    stats.Excellent();
                    break;
                case 7:
                    stats.Excellent();
                    break;
                case 9:
                    stats.Good();
                    break;
                case 12:
                    stats.Bad();
                    break;
                case 19:
                    stats.Good();
                    break;
                case 21:
                    stats.Excellent();
                    break;
                case 31:
                    stats.Good();
                    break;
                case 38:
                    stats.Bad();
                    break;
                case 39:
                    stats.Good();
                    break;
                case 40:
                    stats.Excellent();
                    break;
                case 44:
                    stats.Bad();
                    break;
                case 54:
                    stats.Good();
                    break;
            }
        }
        else if (mainDropdown.value == 2)
        {
            switch (subDropdown.value)
            {
                case 12:
                case 38:
                    stats.Excellent();
                    break;
                case 1:
                case 22:
                case 23:
                case 24:
                case 29:
                case 50:
                    stats.Good();
                    break;
                case 16:
                case 39:
                    stats.Bad();
                    break;
            }
        }
        else if (mainDropdown.value == 3)
        {
            switch(subDropdown.value)
            {
                case 14:
                case 19:
                case 20:
                    stats.Excellent();
                    break;
                case 9:
                case 11:
                case 35:
                case 36:
                case 43:
                case 51:
                case 54:
                case 55:
                    stats.Good();
                    break;
                case 2:
                    stats.Bad();
                    break;
            }
        }
        else if(mainDropdown.value == 4)
        {
            switch (subDropdown.value)
            {
                case 14:
                case 19:
                case 43:
                case 52:
                    stats.Excellent();
                    break;
                case 9:
                case 24:
                case 35:
                case 36:
                case 41:
                case 54:
                    stats.Good();
                    break;
                case 7:
                case 22:
                    stats.Bad();
                    break;
            }
        }
        else if(mainDropdown.value == 5)
        {
            switch (subDropdown.value)
            {
                case 20:
                case 44:
                    stats.Excellent();
                    break;
                case 14:
                case 54:
                    stats.Good();
                    break;
                case 3:
                case 4:
                case 21:
                case 29:
                case 38:
                case 48:
                    stats.Bad();
                    break;
            }
        }
        else if (mainDropdown.value == 6)
        {
            switch (subDropdown.value)
            {
                case 22:
                case 36:
                case 54:
                    stats.Excellent();
                    break;
                case 1:
                case 2:
                case 4:
                case 5:
                case 7:
                case 20:
                case 21:
                case 23:
                case 35:
                case 41:
                case 43:
                    stats.Good();
                    break;
                case 14:
                case 19:
                case 39:
                    stats.Bad();
                    break;
            }
        }
        else if (mainDropdown.value == 7)
        {
            switch (subDropdown.value)
            {
                case 9:
                case 26:
                case 31:
                    stats.Excellent();
                    break;
                case 23:
                case 24:
                case 55:
                    stats.Good();
                    break;
                case 11:
                case 12:
                case 16:
                case 21:
                case 25:
                case 29:
                case 47:
                    stats.Bad();
                    break;
            }
        }
        else if (mainDropdown.value == 8)
        {
            switch (subDropdown.value)
            {
                case 12:
                case 23:
                case 29:
                case 38:
                case 39:
                case 50:
                    stats.Excellent();
                    break;
                case 1:
                case 5:
                case 9:
                case 20:
                case 21:
                case 48:
                    stats.Good();
                    break;
                case 25:
                case 44:
                    stats.Bad();
                    break;
            }
        }
        else if (mainDropdown.value == 9)
        {
            switch (subDropdown.value)
            {
                case 10:
                case 16:
                case 48:
                case 51:
                case 55:
                    stats.Excellent();
                    break;
                case 3:
                case 4:
                case 9:
                case 11:
                case 20:
                case 35:
                    stats.Good();
                    break;
                case 1:
                case 2:
                case 7:
                case 22:
                case 23:
                case 25:
                case 39:
                case 52:
                    stats.Bad();
                    break;
            }
        }
        else if (mainDropdown.value == 10)
        {
            switch (subDropdown.value)
            {
                case 35:
                case 36:
                case 43:
                case 53:
                    stats.Excellent();
                    break;
                case 9:
                case 19:
                case 20:
                case 41:
                    stats.Good();
                    break;
                case 1:
                case 3:
                case 22:
                case 28:
                case 29:
                case 39:
                case 44:
                    stats.Bad();
                    break;
            }
        }

    }
}


