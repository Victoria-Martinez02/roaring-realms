using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    //Image col;
    bool set = false;

    public static HealthBar singleton;

    void Awake()
    {
        if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    // Start is called before the first frame update
    public void SetMaxHP(short health)
    {
        slider.maxValue = health;
        if(!set)
        {
            slider.value = health;
            set = true;
        }

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void resetHP()
    {
        slider.value = slider.maxValue;
    }

    public void UpdateHP(short health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
