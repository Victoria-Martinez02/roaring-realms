using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI time;
    [SerializeField]TextMeshProUGUI season;
    [SerializeField]TextMeshProUGUI date;
    [SerializeField]public float curTime = 360f;
    Season curSeason = Season.SPRING;
    DOTW curDOTW = DOTW.MONDAY;
    short day = 1;

    public bool timePaused = false;

    enum Season{SPRING,SUMMER,FALL,WINTER};

    enum DOTW{MONDAY,TUESDAY,WEDNESDAY,THURSDAY,FRIDAY,SATURDAY,SUNDAY};

    public static Clock singleton;

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
        DisplayDate();
    }

    // Update is called once per frame
    void Update()
    {
        if(!timePaused){
            curTime += Time.deltaTime/1.5f;
        curTime = curTime > 1440f ? 0f : curTime;
        DisplayTime();
        
        if(curTime >= 120f && curTime < 360f)
            NewDay();
        }  
    }

    void DisplayTime()
    {
        int hour = Mathf.FloorToInt(curTime/60.0f);
        int min = Mathf.FloorToInt(curTime-hour*60);
        time.text = string.Format("{0:00}:{1:00}", hour, min);
    }

    void DisplayDate()
    {
        string dotw = "";
        string s = "";

        switch(curDOTW){
            case DOTW.MONDAY:
                dotw = "Mon.";
                break;
            case DOTW.TUESDAY:
                dotw = "Tue.";
                break;
            case DOTW.WEDNESDAY:
                dotw = "Wed.";
                break;
            case DOTW.THURSDAY:
                dotw = "Thu.";
                break;
            case DOTW.FRIDAY:
                dotw = "Fri.";
                break;
            case DOTW.SATURDAY:
                dotw = "Sat.";
                break;
            case DOTW.SUNDAY:
                dotw = "Sun.";
                break;
        }
        
        switch(curSeason){
            case Season.SPRING:
                s = "Spring";
                break;
            case Season.SUMMER:
                s = "Summer";
                break;
            case Season.FALL:
                s = "Fall";
                break;
            case Season.WINTER:
                s = "Winter";
                break;
        }

        season.text = s;
        date.text = dotw + " " + day;
    }

    void NewDay()
    {
        switch(curDOTW){
            case DOTW.MONDAY:
                curDOTW = DOTW.TUESDAY;
                break;
            case DOTW.TUESDAY:
                curDOTW = DOTW.WEDNESDAY;
                break;
            case DOTW.WEDNESDAY:
                curDOTW = DOTW.THURSDAY;
                break;
            case DOTW.THURSDAY:
                curDOTW = DOTW.FRIDAY;
                break;
            case DOTW.FRIDAY:
                curDOTW = DOTW.SATURDAY;
                break;
            case DOTW.SATURDAY:
                curDOTW = DOTW.SUNDAY;
                break;
            case DOTW.SUNDAY:
                curDOTW = DOTW.MONDAY;
                break;
        }
        ++day;

        if(day > 28){
            switch(curSeason){
                case Season.SPRING:
                    curSeason = Season.SUMMER;
                    break;
                case Season.SUMMER:
                    curSeason = Season.FALL;
                    break;
                case Season.FALL:
                    curSeason = Season.WINTER;
                    break;
                case Season.WINTER:
                    curSeason = Season.SPRING;
                    break;
            }
            day = 1;
        }
    }
}
