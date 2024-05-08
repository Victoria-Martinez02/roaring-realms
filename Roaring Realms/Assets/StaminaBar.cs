using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    // Start is called before the first frame update
    Color col;
    bool set = false;

    public static StaminaBar singleton;

    void Awake()
    {
        if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    public void SetMaxSP(short stam)
    {
        slider.maxValue = stam;
        if(!set)
        {
            slider.value = stam;
            set = true;
        }
        col = fill.color;
    }

    public void resetSP()
    {
        slider.value = slider.maxValue;
        col = fill.color;
    }

    public void UpdateSP(short stam)
    {
        slider.value = stam;
    }
}
