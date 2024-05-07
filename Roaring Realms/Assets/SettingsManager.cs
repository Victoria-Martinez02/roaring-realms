using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Toggle tog;
    Resolution initial;
    int width,height;
    // Start is called before the first frame update
    void Start()
    {
        initial.width = Screen.width;
        initial.height = Screen.height;
    }

    public void ChangeResolution(int opt)
    {
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

    public void ChangeView(bool fullscreen)
    {
        Screen.fullScreenMode = fullscreen? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
}
