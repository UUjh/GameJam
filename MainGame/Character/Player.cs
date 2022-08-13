using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fatigue;
    public float senserity;
    public float skill;
    public float task;
    public float fever;
    public float stat;
    public float refresh;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        task += Time.deltaTime;
        fever += Time.deltaTime; 
        fatigue += Time.deltaTime / 2;
        senserity += Time.deltaTime / 2;
        if(task >= 60)
        {
            StatUp();
        }
        if(fever >= 60)
        {
            if (senserity <=20)
            {
                feverCheck(15);
            }
            else if (senserity <= 40)
            {
                feverCheck(30);
            }
            else if (senserity <= 60)
            {
                feverCheck(45);
            }
            else if (senserity <= 80)
            {
                feverCheck(60);
            }
            else if (senserity <= 99)
            {
                feverCheck(75);
            }
            else if (senserity <= 100)
            {
                feverCheck(100);
            }
        }
        if(fatigue >= 100)
        {
            task -= Time.deltaTime;
            fever -= Time.deltaTime;
            senserity -= Time.deltaTime / 2;
            refresh += Time.deltaTime;

            if(refresh >= 10)
            {
                fatigue = 0;
            }
        }
    }

    public void feverCheck(float randFever)
    {
        int Rand = UnityEngine.Random.Range(1, 100);
        for( int i = 0; i < randFever; i++)
        {
            if(Rand == randFever)
            {
                feverOn();
                senserity = 0;
            }
        }
    }
    public void feverOn()
    {
        StatUp();
    }
    public void StatUp()
    {
        int Rand = UnityEngine.Random.Range(1, 2);

        if (skill <= 20)
        {
            if(Rand == 1)
            {
                stat += 3;
            }
            else
            {
                stat += 2;
            }
        }
        if (skill <= 40)
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
        if (skill <= 60)
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
        if (skill <= 80)
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
        if (skill <= 99)
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
        if (skill >= 100)
        {
            stat += 15;
        }
    }

}
