using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignCharacter : MonoBehaviour
{
    public float fatigue = 0;
    public float senserity = 0;
    public float skill = 0;
    public float task = 0;
    public float fever = 0;
    public float stat = 0;
    public float refresh = 0;
    void Start()
    {
        stat = PlayerPrefs.GetInt("Creativity");
        fatigue = PlayerPrefs.GetFloat("DesignFatugue");
        senserity = PlayerPrefs.GetFloat("DesignSenserity");
        skill = PlayerPrefs.GetFloat("DesignSkill");
        task = PlayerPrefs.GetFloat("DesignTask");
        fever = PlayerPrefs.GetFloat("DesignFever");
        refresh = PlayerPrefs.GetFloat("DesignRefresh");
    }

    // Update is called once per frame
    void Update()
    {
        task += Time.deltaTime;
        fever += Time.deltaTime;
        fatigue += Time.deltaTime / 2;
        senserity += Time.deltaTime / 2;
        if (task >= 60)
        {
            StatUp();
            task = 0;
        }
        if (fever >= 60)
        {
            if (senserity <= 20)
            {
                feverCheck(15);

            }
            else if (20 < senserity && senserity <= 40)
            {
                feverCheck(30);
            }
            else if (40 < senserity && senserity <= 60)
            {
                feverCheck(45);
            }
            else if (60 < senserity && senserity <= 80)
            {
                feverCheck(60);
            }
            else if (80 < senserity && senserity <= 99)
            {
                feverCheck(75);
            }
            else if (senserity >= 100)
            {
                feverCheck(100);
            }
        }
        if (fatigue >= 100)
        {
            task -= Time.deltaTime;
            fever -= Time.deltaTime;
            senserity -= Time.deltaTime / 2;
            refresh += Time.deltaTime;

            if (refresh >= 10)
            {
                fatigue = 0;
            }
        }
        PlayerPrefs.SetInt("Creativity", (int)stat);
        PlayerPrefs.SetFloat("DesignFatugue", fatigue);
        PlayerPrefs.SetFloat("DesignSenserity", senserity);
        PlayerPrefs.SetFloat("DesignSkill", skill);
        PlayerPrefs.SetFloat("DesignTask", task);
        PlayerPrefs.SetFloat("DesignFever", fever);
        PlayerPrefs.SetFloat("DesignRefresh", refresh);

    }

    public void feverCheck(float randFever)
    {
        fever = 0;

        int Rand = Random.RandomRange(0, 100);
        Debug.Log(Rand);
        for (int i = 0; i < randFever; i++)
        {
            if (Rand == i)
            {
                feverOn();
                senserity = 0;
                break;
            }
            else
            {
            }
        }
    }
    public void feverOn()
    {
        StatUp();

    }
    public void StatUp()
    {
        int Rand = UnityEngine.Random.Range(1, 3);

        if (skill <= 20)
        {
            if (Rand == 1)
            {
                stat += 3;
            }
            else
            {
                stat += 2;
            }
        }
        else if (skill <= 40)
        {
            if (Rand == 1)
            {
                stat += 4;
            }
            else
            {
                stat += 5;
            }
        }
        else if (skill <= 60)
        {
            if (Rand == 1)
            {
                stat += 6;
            }
            else
            {
                stat += 7;
            }
        }
        else if (skill <= 80)
        {
            if (Rand == 1)
            {
                stat += 8;
            }
            else
            {
                stat += 9;
            }
        }
        else if (skill <= 99)
        {
            if (Rand == 1)
            {
                stat += 10;
            }
            else
            {
                stat += 11;
            }
        }
        else if (skill >= 100)
        {
            stat += 15;
        }
    }
}

