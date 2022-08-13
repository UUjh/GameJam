using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public Slider HPSlider;
    public float hpMax;
    public SoundGameBgm soundGameBgm;
    void Start()
    {
        hpMax = 100;
        HPSlider.maxValue = hpMax;
        HPSlider.value = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        hpMax -= Time.deltaTime * 4;
        HPSlider.value = hpMax;
        if(hpMax<=1)
        {
            soundGameBgm.Die();
        }
    }

    public void HPMiss(float hpPlus)
    {
        hpMax += hpPlus;
    }
    
}
