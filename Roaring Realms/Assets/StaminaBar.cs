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
    public void SetMaxSP(short stam)
    {
        slider.maxValue = stam;
        slider.value = stam;

        col = fill.color;
    }

    public void UpdateSP(short stam)
    {
        slider.value = stam;
    }
}
