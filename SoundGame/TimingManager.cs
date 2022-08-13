using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    public List<GameObject> boxNoteList2 = new List<GameObject>();
    public List<GameObject> boxNoteList3 = new List<GameObject>();
    public SoundGameBgm soundGameBgm;
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    public EffectManager effectManager;
    Vector2[] timingBoxs = null;
    public AudioSource effectSoundMiss;
    public AudioSource effectSoundLeftOK,effectSoundRightOK,effectSoundSpaceOK;
    public HP hp;
    void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];
        
        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / (5/4),
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTiming()
    {

        for(int i = 0; i < boxNoteList.Count; i++)
        {


            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for(int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    effectSoundLeftOK.PlayOneShot(effectSoundLeftOK.clip);
                    Destroy(boxNoteList[i]);
                    effectManager.NoteHitEffect();
                    boxNoteList.RemoveAt(i);
                    if (x == 0)
                    {
                        soundGameBgm.ScoreUp(100);
                        Debug.Log("Perfect");
                        effectManager.ScoreEffect();
                        hp.HPMiss(4);
                    }
                    else if (x == 1)
                    {
                        soundGameBgm.ScoreUp(70);
                        Debug.Log("Great");
                        effectManager.ScoreEffect2();
                        hp.HPMiss(2);
                    }
                    else if (x == 2)
                    {
                        soundGameBgm.ScoreUp(50);
                        Debug.Log("Good");
                        effectManager.ScoreEffect3();
                        hp.HPMiss(-2);

                    }
                    else if (x == 3)
                    {
                        soundGameBgm.ScoreUp(30);
                        Debug.Log("Soso");
                        effectManager.ScoreEffect4();
                        hp.HPMiss(-4);

                    }
                    return;
                }
            }
        }
        effectManager.ScoreEffect5();
        hp.HPMiss(-6);
        effectManager.NoteHitEffect();
        soundGameBgm.ScoreUp(-50);
        Debug.Log("Miss");
        effectSoundMiss.PlayOneShot(effectSoundMiss.clip);
    }
    public void CheckTiming2()
    {

        for (int i = 0; i < boxNoteList2.Count; i++)
        {


            float t_notePosX = boxNoteList2[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    effectSoundRightOK.PlayOneShot(effectSoundRightOK.clip);
                    Destroy(boxNoteList2[i]);
                    effectManager.NoteHitEffect();
                    boxNoteList2.RemoveAt(i);

                    if (x == 0)
                    {
                        soundGameBgm.ScoreUp(100);
                        Debug.Log("Perfect");
                        effectManager.ScoreEffect();
                        hp.HPMiss(4);

                    }
                    else if (x == 1)
                    {
                        soundGameBgm.ScoreUp(70);
                        Debug.Log("Great");
                        effectManager.ScoreEffect2();
                        hp.HPMiss(2);

                    }
                    else if (x == 2)
                    {
                        soundGameBgm.ScoreUp(50);
                        Debug.Log("Good");
                        effectManager.ScoreEffect3();
                        hp.HPMiss(-2);

                    }
                    else if (x == 3)
                    {
                        soundGameBgm.ScoreUp(30);
                        Debug.Log("Soso");
                        effectManager.ScoreEffect4();
                        hp.HPMiss(-4);

                    }
                    return;
                }
            }
        }
        hp.HPMiss(-6);
        effectManager.ScoreEffect5();
        effectManager.NoteHitEffect();
        soundGameBgm.ScoreUp(-50);
        Debug.Log("Miss");
        effectSoundMiss.PlayOneShot(effectSoundMiss.clip);
    }
    public void CheckTiming3()
    {

        for (int i = 0; i < boxNoteList3.Count; i++)
        {


            float t_notePosX = boxNoteList3[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    effectSoundSpaceOK.PlayOneShot(effectSoundSpaceOK.clip);
                    Destroy(boxNoteList3[i]);
                    effectManager.NoteHitEffect();
                    boxNoteList3.RemoveAt(i);

                    if (x == 0)
                    {
                        soundGameBgm.ScoreUp(100);
                        Debug.Log("Perfect");
                        effectManager.ScoreEffect();
                        hp.HPMiss(4);

                    }
                    else if (x == 1)
                    {
                        soundGameBgm.ScoreUp(70);
                        Debug.Log("Great");
                        effectManager.ScoreEffect2();
                        hp.HPMiss(2);

                    }
                    else if (x == 2)
                    {
                        soundGameBgm.ScoreUp(50);
                        Debug.Log("Good");
                        effectManager.ScoreEffect3();
                        hp.HPMiss(-4);

                    }
                    else if (x == 3)
                    {
                        soundGameBgm.ScoreUp(30);
                        Debug.Log("Soso");
                        effectManager.ScoreEffect4();
                        hp.HPMiss(-8);

                    }
                    return;
                }
            }
        }
        hp.HPMiss(-20);
        effectManager.ScoreEffect5();
        effectManager.NoteHitEffect();
        soundGameBgm.ScoreUp(-50);
        Debug.Log("Miss");
        effectSoundMiss.PlayOneShot(effectSoundMiss.clip);
    }
}
