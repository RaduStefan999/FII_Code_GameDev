using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    public bool TimeStatus = false;
    public GameObject Play, Pause, TechTexture;

    public int GameSpeed = 5;

    protected double nextUpdate;

    public struct InGameTime {
        public int Day;
        public int Month;
        public int Year;
    };

    public InGameTime curentTime;


    public struct RegionData {
        public float Happynes;
        public float Polution;
        public float Industry;
        public GameObject GraphicComponent;
    };

    public struct Regions {
        public RegionData Europe;
        public RegionData AfricaAarabia;
        public RegionData SAfrica;
        public RegionData NAmerica;
        public RegionData SAmerica;
        public RegionData Antarctica;
        public RegionData NAsia;
        public RegionData SAsia;
        public RegionData Australia;
        public RegionData IcelandGreenland;
    }


    public Text UI_Time;
    public Regions World;

    public RawImage TechnologyImg;
    public RawImage HappynesImg;
    public RawImage NatureImg;
    public RawImage IndustryImg;

    Color lerpedColor = Color.white;


    void Start()
    {
        //Initialise Vars
        curentTime.Day = 28;
        curentTime.Month = 3;
        curentTime.Year = 2019;

        nextUpdate = (1f / GameSpeed);

        //ConstructingTheWorld
        World.Europe.GraphicComponent = GameObject.Find("Europe");
        World.Europe.Happynes = 0.8f;
        World.Europe.Polution = 0.6f;
        World.Europe.Industry = 0.75f;

        World.AfricaAarabia.GraphicComponent = GameObject.Find("Africa-Arabia");
        World.AfricaAarabia.Happynes = 0.3f;
        World.AfricaAarabia.Polution = 0.4f;
        World.AfricaAarabia.Industry = 0.3f;

        World.Australia.GraphicComponent = GameObject.Find("Australia");
        World.Australia.Happynes = 0.75f;
        World.Australia.Polution = 0.7f;
        World.Australia.Industry = 0.5f;

        World.SAfrica.GraphicComponent = GameObject.Find("S.Africa");
        World.SAfrica.Happynes = 0.25f;
        World.SAfrica.Polution = 0.45f;
        World.SAfrica.Industry = 0.35f;

        World.NAsia.GraphicComponent = GameObject.Find("N.Asia");
        World.NAsia.Happynes = 0.55f;
        World.NAsia.Polution = 0.5f;
        World.NAsia.Industry = 0.6f;

        World.SAsia.GraphicComponent = GameObject.Find("S.Asia");
        World.SAsia.Happynes = 0.45f;
        World.SAsia.Polution = 0.3f;
        World.SAsia.Industry = 0.85f;

        World.Antarctica.GraphicComponent = GameObject.Find("Antarctica");
        World.Antarctica.Happynes = 0.65f;
        World.Antarctica.Polution = 0.95f;
        World.Antarctica.Industry = 0.1f;

        World.IcelandGreenland.GraphicComponent = GameObject.Find("Greenland-Iceland");
        World.IcelandGreenland.Happynes = 0.9f;
        World.IcelandGreenland.Polution = 0.85f;
        World.IcelandGreenland.Industry = 0.25f;

        World.NAmerica.GraphicComponent = GameObject.Find("N.America");
        World.NAmerica.Happynes = 0.7f;
        World.NAmerica.Polution = 0.65f;
        World.NAmerica.Industry = 0.8f;

        World.SAmerica.GraphicComponent = GameObject.Find("S.America");
        World.SAmerica.Happynes = 0.55f;
        World.SAmerica.Polution = 0.55f;
        World.SAmerica.Industry = 0.5f;
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

    public void DisplayHappynes () {
        TechTexture.SetActive(false);
        TechnologyImg.color = Color.white;
        HappynesImg.color = Color.yellow;
        NatureImg.color = Color.white;
        IndustryImg.color = Color.white;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Europe.Happynes);
        World.Europe.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.AfricaAarabia.Happynes);
        World.AfricaAarabia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Australia.Happynes);
        World.Australia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAfrica.Happynes);
        World.SAfrica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.NAsia.Happynes);
        World.NAsia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAsia.Happynes);
        World.SAsia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Antarctica.Happynes);
        World.Antarctica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.IcelandGreenland.Happynes);
        World.IcelandGreenland.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.NAmerica.Happynes);
        World.NAmerica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAmerica.Happynes);
        World.SAmerica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;
    }

    public void DisplayPolution () {
        TechTexture.SetActive(false);
        TechnologyImg.color = Color.white;
        HappynesImg.color = Color.white;
        NatureImg.color = Color.yellow;
        IndustryImg.color = Color.white;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Europe.Polution);
        World.Europe.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.AfricaAarabia.Polution);
        World.AfricaAarabia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Australia.Polution);
        World.Australia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAfrica.Polution);
        World.SAfrica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.NAsia.Polution);
        World.NAsia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAsia.Polution);
        World.SAsia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Antarctica.Polution);
        World.Antarctica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.IcelandGreenland.Polution);
        World.IcelandGreenland.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.NAmerica.Polution);
        World.NAmerica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAmerica.Polution);
        World.SAmerica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;
    }

    public void DisplayIndustry () {
        TechTexture.SetActive(false);
        TechnologyImg.color = Color.white;
        HappynesImg.color = Color.white;
        NatureImg.color = Color.white;
        IndustryImg.color = Color.yellow;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Europe.Industry);
        World.Europe.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.AfricaAarabia.Industry);
        World.AfricaAarabia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Australia.Industry);
        World.Australia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAfrica.Industry);
        World.SAfrica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;
        
        lerpedColor = Color.Lerp(Color.red, Color.blue, World.NAsia.Industry);
        World.NAsia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAsia.Industry);
        World.SAsia.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.Antarctica.Industry);
        World.Antarctica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.IcelandGreenland.Industry);
        World.IcelandGreenland.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;
        
        lerpedColor = Color.Lerp(Color.red, Color.blue, World.NAmerica.Industry);
        World.NAmerica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;

        lerpedColor = Color.Lerp(Color.red, Color.blue, World.SAmerica.Industry);
        World.SAmerica.GraphicComponent.GetComponent<SpriteRenderer>().color = lerpedColor;
    }

    public void DisplayTechnology () {
        TechTexture.SetActive(true);
        TechnologyImg.color = Color.yellow;
        HappynesImg.color = Color.white;
        NatureImg.color = Color.white;
        IndustryImg.color = Color.white;
    }

    public void Develop_Europe () {
        Debug.Log ("Develop_Europe");
    }

    public void Develop_AfricaArabia () {
        Debug.Log ("Develop_AfricaArabia");
    }

    public void Develop_SAfrica () {
        Debug.Log ("Develop_SAfrica");
    }

    public void Develop_Australia () {
        Debug.Log ("Develop_Australia");
    }

    public void Develop_SAsia () {
        Debug.Log ("Develop_SAsia");
    }

    public void Develop_NAsia () {
        Debug.Log ("Develop_NAsia");
    }

    public void Develop_Antarctica () {
        Debug.Log ("Develop_Antarctica");
    }

    public void Develop_GreenlandIceland () {
        Debug.Log ("Develop_GreenlandIceland");
    }

    public void Develop_NAmerica () {
        Debug.Log ("Develop_NAmerica");
    }

    public void Develop_SAmerica () {
        Debug.Log ("Develop_SAmerica");
    }
}
