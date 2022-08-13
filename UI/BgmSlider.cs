using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BgmSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider mainBgmSlider;
    void Start()
    {
        mainBgmSlider.value = PlayerPrefs.GetFloat("BGM");
        
    }
    public void AudioControl()
    {
        float sound = mainBgmSlider.value;
        if (sound == -40f)
        {
            audioMixer.SetFloat("BGM", -80);
        }
        else
        {
            audioMixer.SetFloat("BGM", sound);
            PlayerPrefs.SetFloat("BGM", sound);
        }

    }

    void Update()
    {

    }

}