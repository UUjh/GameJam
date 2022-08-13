using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EffectSoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider effectSoundSlider;
    void Start()
    {
        effectSoundSlider.value = PlayerPrefs.GetFloat("EffectSound");

    }
    public void AudioControl()
    {
        float sound = effectSoundSlider.value;
        if (sound == -40f)
        {
            PlayerPrefs.SetFloat("EffectSound", -80f);
        }
        else
        {
            PlayerPrefs.SetFloat("EffectSound", sound);
        }

    }

    void Update()
    {

    }
}
