using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sunlight : MonoBehaviour
{
    Light2D sun;
    [SerializeField] Gradient gradient;
    [SerializeField] Clock clock;
    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DayToNight(clock.curTime);
    }

    void DayToNight(float time)
    {
        sun.color = gradient.Evaluate(time/1440);
    }
}
