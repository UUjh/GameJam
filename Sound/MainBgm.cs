using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MainBgm : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioMixer audioMixer;
    private GameObject[] musics;
    private void Awake()
    {
        float NowSoundSize = PlayerPrefs.GetFloat("BGM");
        audioMixer.SetFloat("BGM", NowSoundSize);
        musics = GameObject.FindGameObjectsWithTag("Music");
        if (musics.Length >= 2)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            return;
        }
        else
        {
            audioSource.Play();
        }
    }
    
    public void StopMusic()
    {
        audioSource.Stop();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
