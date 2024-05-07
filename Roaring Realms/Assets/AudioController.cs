using System.Collections;
using System.Collections.Generic;
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

    void playMusic()
    {
        
    }
}
