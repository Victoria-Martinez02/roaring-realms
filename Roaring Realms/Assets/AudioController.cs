using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] Slider master;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    [SerializeField] AudioMixer mixer;
    public static AudioController singleton;
    string curPlaying = "";

    [System.Serializable]
    public class Audio{
        public string name;
        public AudioClip clip;
    }

    public Audio[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;

    void Awake()
    {
        if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        if(PlayerPrefs.HasKey("masterVol"))
            loadPrefs();

        AdjustMaster();
        AdjustMusic();
        AdjustSFX();

        AudioController.singleton.playMusic("Menu Theme");
    }

    public void AdjustMaster()
    {
        float vol = master.value;
        mixer.SetFloat("master",Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("masterVol", vol);
    }

    public void AdjustMusic()
    {
        float vol = music.value;
        mixer.SetFloat("music",Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("musicVol", vol);
    }

    public void AdjustSFX()
    {
        float vol = sfx.value;
        mixer.SetFloat("sfx",Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("sfxVol", vol);
    }

    void loadPrefs()
    {
        master.value = PlayerPrefs.GetFloat("masterVol");
        music.value = PlayerPrefs.GetFloat("musicVol");
        sfx.value = PlayerPrefs.GetFloat("sfxVol");
    }

    public void playMusic(string name)
    {
        Audio a = Array.Find(musicAudio, x => x.name == name);

        if(a != null && !a.Equals(curPlaying))
        {
            musicSource.clip = a.clip;
            musicSource.Play();
        }
    }

    public void playSFX(string name)
    {
        Audio a = Array.Find(sfxAudio, x => x.name == name);

        if(a != null)
        {
            sfxSource.clip = a.clip;
            sfxSource.Play();
        }
    }
}
