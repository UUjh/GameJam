using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlor : MonoBehaviour
{
    public AudioSource effectSoundMiss;
    TimingManager timingManager;
    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            timingManager.CheckTiming();

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            timingManager.CheckTiming2();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timingManager.CheckTiming3();

        }
    }
}
