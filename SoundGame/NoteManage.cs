using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManage : MonoBehaviour
{
    public float bpm;
    public float bpm2;
    public int bpm3;
    public HP hp;
    double currentTime = 0d;
    double currentTime2 = 0d;
    double currentTime3 = 0d;

    TimingManager timingManager;
    public SoundGameBgm soundGameBgm;
    public EffectManager effectManager;
    public AudioSource effectSoundMiss;
    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] Transform tfNoteAppear2 = null;

    [SerializeField] GameObject goNotc = null;
    [SerializeField] GameObject goNotc2 = null;
    [SerializeField] GameObject goNotc3 = null;




    void Start()
    {
        bpm = 60;
        bpm2 = 96;
        bpm3 = 10;
        timingManager = GetComponent<TimingManager>();
     
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTime2 += Time.deltaTime;
        currentTime3 += Time.deltaTime;
        if (soundGameBgm.setTime <=30)
        {
            bpm += Time.deltaTime ;
            bpm2 += Time.deltaTime ;

        }

        if (currentTime >= 60d / bpm && currentTime2 >= 60d / bpm2)
        {
            GameObject t_notc = Instantiate(goNotc, tfNoteAppear.position, Quaternion.identity);
            t_notc.transform.SetParent(this.transform);
            timingManager.boxNoteList.Add(t_notc);
            currentTime -= 60d / bpm;
            currentTime2 -= 60d / bpm2;
        }
        else
        {
            if (currentTime >= 60d / bpm)
            {
                GameObject t_notc = Instantiate(goNotc, tfNoteAppear.position, Quaternion.identity);
                t_notc.transform.SetParent(this.transform);
                timingManager.boxNoteList.Add(t_notc);
                currentTime -= 60d / bpm;
            }
            if (currentTime2 >= 60d / bpm2)
            {
                GameObject t_notc2 = Instantiate(goNotc2, tfNoteAppear.position, Quaternion.identity);
                t_notc2.transform.SetParent(this.transform);
                timingManager.boxNoteList2.Add(t_notc2);
                currentTime2 -= 60d / bpm2;
            }
            if (currentTime3 >= 60d / bpm3)
            {
                GameObject t_notc3 = Instantiate(goNotc3, tfNoteAppear2.position, Quaternion.identity);
                t_notc3.transform.SetParent(this.transform);
                timingManager.boxNoteList3.Add(t_notc3);
                currentTime3 -= 60d / bpm3;
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note")) 
        {
            timingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            soundGameBgm.ScoreUp(-50);
            Debug.Log("Miss");
            effectSoundMiss.PlayOneShot(effectSoundMiss.clip);
            effectManager.ScoreEffect5();
            hp.HPMiss(-6);


        }
        if (collision.CompareTag("Note2"))
        {
            timingManager.boxNoteList2.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            soundGameBgm.ScoreUp(-50);
            Debug.Log("Miss");
            effectSoundMiss.PlayOneShot(effectSoundMiss.clip);
            effectManager.ScoreEffect5();
            hp.HPMiss(-6);


        }
        if (collision.CompareTag("Note3"))
        {
            timingManager.boxNoteList3.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Miss");
            effectSoundMiss.PlayOneShot(effectSoundMiss.clip);
            effectManager.ScoreEffect5();
            hp.HPMiss(-20);


        }
    }
}
