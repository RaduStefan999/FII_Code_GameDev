using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    public bool TimeStatus = false;
    public GameObject Play, Pause;

    public int GameSpeed = 5;

    protected double nextUpdate;

    public struct InGameTime {
        public int Day;
        public int Month;
        public int Year;
    };

    public InGameTime curentTime;

    public Text UI_Time;


    void Start()
    {
        //Initialise Vars
        curentTime.Day = 28;
        curentTime.Month = 3;
        curentTime.Year = 2019;

        nextUpdate = (1f / GameSpeed);
    }


    void Update()
    {
        if (Time.time >= nextUpdate) {
            nextUpdate = Time.time + (1f / GameSpeed);
            UpdateEveryHalfSecond ();
        }
    }

    void UpdateEveryHalfSecond () {
        
        if (TimeStatus == true) {
            DaylyUpdate ();
            curentTime.Day ++;
            if (curentTime.Day >= 31)   {
                curentTime.Day = 1;
                MonthlyUpdate ();
                curentTime.Month ++;
                if (curentTime.Month >= 13) {
                    curentTime.Month = 1;
                    YearlyUpdate ();
                    curentTime.Year ++;
                }
            }
        }

        AplyGraphics ();
    }


    void AplyGraphics () {
        UI_Time.text = curentTime.Day + "/" + curentTime.Month + "/" + curentTime.Year;
    }


    void DaylyUpdate () {

    }

    void MonthlyUpdate () {

    }

    void YearlyUpdate () {

    }

    public void StartTime () {
        Play.SetActive(false);
        Pause.SetActive(true);
        TimeStatus = true;
    }

    public void StopTime () {
        Play.SetActive(true);
        Pause.SetActive(false);
        TimeStatus = false;
    }
}
