using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Toggle tog;
    [SerializeField] TMP_Dropdown drop;
    Resolution initial;
    [SerializeField]GameObject opt;
    bool active = false;
    int width,height;

    public static SettingsManager singleton;

    void Awake()
    {
        if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        initial.width = Screen.currentResolution.width;
        initial.height = Screen.currentResolution.width;
    }

    public void ChangeResolution()
    {
        int opt = drop.value;

        switch(opt)
        {
            case 0:
                width = initial.width;
                height = initial.height;
                break;
            case 1:
                width = 1920;
                height = 1080;
                break;
            case 2:
                width = 1366;
                height = 768;
                break;
            case 3:
                width = 1280;
                height = 1024;
                break;
            case 4:
                width = 1024;
                height = 768;
                break;
        }
        Debug.Log(width);
        Screen.SetResolution(width,height,Screen.fullScreen);
    }

    public void ChangeView()
    {
        bool fullscreen = tog.isOn;
        Screen.fullScreenMode = fullscreen? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Debug.Log(fullscreen);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ToggleOptions()
    {
        Clock.singleton.timePaused = !Clock.singleton.timePaused;
        active = !active;
        opt.SetActive(active);
    }
}
