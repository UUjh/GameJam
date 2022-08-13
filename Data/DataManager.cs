using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public TMP_InputField inputTeamName;
    public TMP_Dropdown genreMain;
    public TMP_Dropdown genreSub;

    private string teamName;

    public int fun;
    public int creativity;
    public int graphic;
    public int sound;
    public int fatigue; // 피로도
 
    public int Fun { get; set; }

    public int Creativity { get; set; }

    public int Graphic { get; set; }

    public int Sound { get; set; }

    public int Fatigue { get; set; }


    EventManager eventManager;


    public void Save()
    {
        teamName = inputTeamName.text;
        PlayerPrefs.SetString("TeamName", teamName);
        PlayerPrefs.SetInt("Fun", fun);
        PlayerPrefs.SetInt("Creativity", creativity);
        PlayerPrefs.SetInt("Graphic", graphic);
        PlayerPrefs.SetInt("Sound", sound);
        PlayerPrefs.SetInt("Fatigue", fatigue);

        PlayerPrefs.SetInt("LoadDataCheck", 1);

        Debug.Log("플레이어 정보 저장 ");
        
        Debug.Log(teamName);
        Debug.Log(creativity);
        Debug.Log(fun);
        Debug.Log(creativity);
        Debug.Log(graphic);
        Debug.Log(sound);
        Debug.Log(fatigue);
    }

    public void Load()
    {
        
        if (PlayerPrefs.HasKey("TeamName"))
        {
            teamName = PlayerPrefs.GetString("TeamName");
        }
        fun = PlayerPrefs.GetInt("Fun");
        creativity = PlayerPrefs.GetInt("Creativity");
        graphic = PlayerPrefs.GetInt("Graphic");
        sound = PlayerPrefs.GetInt("Sound");
        fatigue = PlayerPrefs.GetInt("Fatigue");

        Debug.Log("플레이어 정보 불러오기");
    }

    
    public void DataReset()
    {
        PlayerPrefs.SetString("TeamName", null);
        PlayerPrefs.SetInt("Fun", 0);
        PlayerPrefs.SetInt("Creativity", 0);
        PlayerPrefs.SetInt("Graphic", 0);
        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.SetInt("Fatigue", 0);
        PlayerPrefs.SetInt("ProGress", 0);
        PlayerPrefs.SetString("MainTema", null);
        PlayerPrefs.SetString("SubTema", null);
        PlayerPrefs.SetInt("LoadDataCheck", 0);

        PlayerPrefs.SetInt("Fun", 0);
        PlayerPrefs.SetFloat("FunFatugue", 0);
        PlayerPrefs.SetFloat("FunSenserity", 0);
        PlayerPrefs.SetFloat("FunSkill", 0);
        PlayerPrefs.SetFloat("FunTask", 0);
        PlayerPrefs.SetFloat("FunFever", 0);
        PlayerPrefs.SetFloat("FunRefresh", 0);

        PlayerPrefs.SetInt("Creativity", 0);
        PlayerPrefs.SetFloat("DesignFatugue", 0);
        PlayerPrefs.SetFloat("DesignSenserity", 0);
        PlayerPrefs.SetFloat("DesignSkill", 0);
        PlayerPrefs.SetFloat("DesignTask", 0);
        PlayerPrefs.SetFloat("DesignFever", 0);
        PlayerPrefs.SetFloat("DesignRefresh", 0);

        PlayerPrefs.SetInt("Graphic", 0);
        PlayerPrefs.SetFloat("GraphicFatugue", 0);
        PlayerPrefs.SetFloat("GraphicSenserity", 0);
        PlayerPrefs.SetFloat("GraphicSkill", 0);
        PlayerPrefs.SetFloat("GraphicTask", 0);
        PlayerPrefs.SetFloat("GraphicFever", 0);
        PlayerPrefs.SetFloat("GraphicRefresh", 0);

        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.SetFloat("SoundFatugue", 0);
        PlayerPrefs.SetFloat("SoundSenserity", 0);
        PlayerPrefs.SetFloat("SoundSkill", 0);
        PlayerPrefs.SetFloat("SoundTask", 0);
        PlayerPrefs.SetFloat("SoundFever", 0);
        PlayerPrefs.SetFloat("SoundRefresh", 0);

        PlayerPrefs.SetInt("SavePoint1", 0);
        PlayerPrefs.SetInt("SavePoint2", 0);
        PlayerPrefs.SetInt("SavePoint3", 0);
        PlayerPrefs.SetInt("SavePoint4", 0);
        PlayerPrefs.SetInt("SavePoint5", 0);
        PlayerPrefs.SetInt("SavePoint6", 0);
        PlayerPrefs.SetInt("SavePoint7", 0);
        PlayerPrefs.SetInt("SavePoint8", 0);
        PlayerPrefs.SetInt("SavePoint9", 0);
    }


}
