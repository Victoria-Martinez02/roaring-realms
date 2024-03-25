using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI time;
    [SerializeField]float curTime = 360f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime/2;
        curTime = curTime > 1440f ? 0f : curTime;
        DisplayTime();
    }

    void DisplayTime()
    {
        int hour = Mathf.FloorToInt(curTime/60.0f);
        int min = Mathf.FloorToInt(curTime-hour*60);
        time.text = string.Format("{0:00}:{1:00}", hour, min);
    }
}
