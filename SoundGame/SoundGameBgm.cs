using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundGameBgm : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI noteTiming;
    public AudioMixer audioMixer;
    public float setTime;
    float sec;
    public float timeSec;
    float audioGameSound;
    float score;
    string color;
    void Start()
    {
        setTime = 60f;
        timeSec = 0;
        audioGameSound = PlayerPrefs.GetFloat("BGM");
        audioMixer.SetFloat("BGM", -80);
        audioMixer.SetFloat("SoundGameBgm", audioGameSound);
    }

  
    void Update()
    {
        setTime -= Time.deltaTime;
        timeSec += Time.deltaTime;
        if (setTime >= 30f)
        {
            timerText.text = (int)setTime +"";
        }
        if (setTime < 30f)
        {
            timerText.text = "<color=red>" + (int)setTime + "" + "</color>";
        }
        if (setTime <= 0)
        {
            Debug.Log("½Ã°£ ³¡");
            audioMixer.SetFloat("SoundGameBgm", -80);
            audioMixer.SetFloat("BGM", audioGameSound);
            Die();

        }


    }

    public void ScoreUp(int scoreup)
    {
        score += scoreup;
    }
    public void Die()
    {
        if (timeSec >= 60)
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") + 10);
        }
        else if (timeSec >= 45)
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") + 7);
        }
        else if (timeSec >= 30)
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") + 5);
        }
        else if (timeSec >= 15)
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") + 2);
        }
        else if (timeSec >= 0)
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound"));
        }
        audioMixer.SetFloat("SoundGameBgm", -80);
        audioMixer.SetFloat("BGM", audioGameSound);
        SceneManager.LoadScene("MainGame");

    }
}
