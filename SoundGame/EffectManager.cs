using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public Animator noteHit = null;
    public Animator PerfectEffect = null;
    public Animator GreatEffect = null;
    public Animator GoodEffect = null;
    public Animator SosoEffect = null;
    public Animator MissEffect = null;

    string hit = "Hit";
    string perfect = "Perfect";
    string great = "Great";
    string good = "Good";
    string soso = "Soso";
    string miss = "Miss";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NoteHitEffect()
    {
        noteHit.SetTrigger(hit);
    }
    public void ScoreEffect()
    {
        PerfectEffect.SetTrigger(perfect);
    }
    public void ScoreEffect2()
    {
        GreatEffect.SetTrigger(great);
    }
    public void ScoreEffect3()
    {
        GoodEffect.SetTrigger(good);
    }
    public void ScoreEffect4()
    {
        SosoEffect.SetTrigger(soso);
    }
    public void ScoreEffect5()
    {
        MissEffect.SetTrigger(miss);
    }
}

