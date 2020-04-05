﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class UI_ColorChangeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public bool Chinese;
    public ColorChange Point1;
    public ColorChange Point2;
    public UI_SineColor Sine0;
    public UI_SineColor Sine1;
    public UI_SineColor Sine2;
    public UI_SineColor Sine3;
    public UI_SineColor Sine4;
    public UI_SineColor Sine5;

    //public CircleMask circleMask;
    //public CustomizeButton customizeButton;



    private Image myImage;
    public TextMeshProUGUI ButtonText;

    public UI_OptionsButton optionsButton;
    private string RainbowText = "Rainbow";
    private string FireText = "Fire";
    private string AirText = "Air";
    private string EarthText = "Earth";
    private string WaterText = "Water";
    private string AetherText = "Aether";
    private string OrderText = "Order";
    private string ChaosText = "Chaos";

    private string RainbowTextChinese = "彩虹";
    private string FireTextChinese = "火";
    private string AirTextChinese = "空气";
    private string EarthTextChinese = "地球";
    private string WaterTextChinese = "水";
    private string AetherTextChinese = "醚";
    private string OrderTextChinese = "订购";
    private string ChaosTextChinese = "混沌";

    public int ColorIndex1;
    public int ColorIndex2;

    private Vector3 imageScaleDefault;
    private bool hasExited;

    public bool Left;
    public float myAlpha; 
    // Use this for initialization
    void Start()
    {

        imageScaleDefault = transform.localScale;

        if (!Chinese)
        {
            if (Left)
            {
                if (PlayerPrefs.GetInt("LeftColor") == 0)
                {
                    ButtonText.text = RainbowText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 1)
                {
                    ButtonText.text = FireText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 2)
                {
                    ButtonText.text = AirText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 3)
                {
                    ButtonText.text = EarthText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 4)
                {
                    ButtonText.text = WaterText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 5)
                {
                    ButtonText.text = AetherText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 6)
                {
                    ButtonText.text = ChaosText;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 7)
                {
                    ButtonText.text = OrderText;
                }
            }
            else if (!Left)
            {
                if (PlayerPrefs.GetInt("RightColor") == 0)
                {
                    ButtonText.text = RainbowText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 1)
                {
                    ButtonText.text = FireText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 2)
                {
                    ButtonText.text = AirText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 3)
                {
                    ButtonText.text = EarthText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 4)
                {
                    ButtonText.text = WaterText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 5)
                {
                    ButtonText.text = AetherText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 6)
                {
                    ButtonText.text = ChaosText;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 7)
                {
                    ButtonText.text = OrderText;
                }
            }
        }
        else if (Chinese)
        {
            if (Left)
            {
                if (PlayerPrefs.GetInt("LeftColor") == 0)
                {
                    ButtonText.text = RainbowTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 1)
                {
                    ButtonText.text = FireTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 2)
                {
                    ButtonText.text = AirTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 3)
                {
                    ButtonText.text = EarthTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 4)
                {
                    ButtonText.text = WaterTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 5)
                {
                    ButtonText.text = AetherTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 6)
                {
                    ButtonText.text = ChaosTextChinese;
                }
                else if (PlayerPrefs.GetInt("LeftColor") == 7)
                {
                    ButtonText.text = OrderTextChinese;
                }
            }
            else if (!Left)
            {
                if (PlayerPrefs.GetInt("RightColor") == 0)
                {
                    ButtonText.text = RainbowTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 1)
                {
                    ButtonText.text = FireTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 2)
                {
                    ButtonText.text = AirTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 3)
                {
                    ButtonText.text = EarthTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 4)
                {
                    ButtonText.text = WaterTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 5)
                {
                    ButtonText.text = AetherTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 6)
                {
                    ButtonText.text = ChaosTextChinese;
                }
                else if (PlayerPrefs.GetInt("RightColor") == 7)
                {
                    ButtonText.text = OrderTextChinese;
                }
            }
        }

        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!circleMask.Open)
        {
            myImage.color = Alpha;
            //ButtonText.color = GreyAlpha;
            //ButtonText.enabled = false;
            Sine0.StopCoroutine("StartSequence");
            Sine1.StopCoroutine("StartSequence");
            Sine2.StopCoroutine("StartSequence");

            Sine3.StopCoroutine("StartSequence");
            Sine4.StopCoroutine("StartSequence");
            Sine5.StopCoroutine("StartSequence");


            Sine0.ColorIndex = ColorIndex1;
            Sine1.ColorIndex = ColorIndex1;
            Sine2.ColorIndex = ColorIndex1;


            Sine3.ColorIndex = ColorIndex2;
            Sine4.ColorIndex = ColorIndex2;
            Sine5.ColorIndex = ColorIndex2;

            Sine0.Started = false;
            Sine1.Started = false;
            Sine2.Started = false;

            Sine3.Started = false;
            Sine4.Started = false;
            Sine5.Started = false;

        }
        */

        myImage.color = new Color (Sine0.LerpColor.r, Sine0.LerpColor.g, Sine0.LerpColor.b, myAlpha);
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        hasExited = false;
        myAlpha = .75f;
        transform.localScale = imageScaleDefault * .98f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasExited = true;
        myAlpha = 1;
        transform.localScale = imageScaleDefault;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (hasExited)
        {
            hasExited = false;
            return;
        }
        myAlpha = 1;
        transform.localScale = imageScaleDefault;

        Sine0.StopCoroutine("StartSequence");
        Sine1.StopCoroutine("StartSequence");
        Sine2.StopCoroutine("StartSequence");

        Sine3.StopCoroutine("StartSequence");
        Sine4.StopCoroutine("StartSequence");
        Sine5.StopCoroutine("StartSequence");



        Sine0.ColorIndex = ColorIndex1;
        Sine1.ColorIndex = ColorIndex1;
        Sine2.ColorIndex = ColorIndex1;

        Sine3.ColorIndex = ColorIndex2;
        Sine4.ColorIndex = ColorIndex2;
        Sine5.ColorIndex = ColorIndex2;
        Sine0.LerpColor = Color.white;
        Sine1.LerpColor = Color.white;
        Sine2.LerpColor = Color.white;
        Sine0.Started = false;
        Sine1.Started = false;
        Sine2.Started = false;

        Sine3.Started = false;
        Sine4.Started = false;
        Sine5.Started = false;

        if (!Chinese)
        {
            if (Point1.IsRainbow)
            {
                Point1.IsRainbow = false;
                Point1.IsFire = true;
                ButtonText.text = FireText;
                SaveColor(1);
            }
            else if (Point1.IsFire)
            {
                Point1.IsFire = false;
                Point1.IsAir = true;
                ButtonText.text = AirText;
                SaveColor(2);
            }
            else if (Point1.IsAir)
            {
                Point1.IsAir = false;
                Point1.IsEarth = true;
                ButtonText.text = EarthText;
                SaveColor(3);
            }
            else if (Point1.IsEarth)
            {
                Point1.IsEarth = false;
                Point1.IsWater = true;
                ButtonText.text = WaterText;
                SaveColor(4);
            }
            else if (Point1.IsWater)
            {
                Point1.IsWater = false;
                Point1.IsAether = true;
                ButtonText.text = AetherText;
                SaveColor(5);
            }
            else if (Point1.IsAether)
            {
                Point1.IsAether = false;
                Point1.IsDark = true;
                ButtonText.text = ChaosText;
                SaveColor(6);
            }
            else if (Point1.IsDark)
            {
                Point1.IsDark = false;
                Point1.IsLight = true;
                ButtonText.text = OrderText;
                SaveColor(7);
            }
            else if (Point1.IsLight)
            {
                Point1.IsLight = false;
                Point1.IsRainbow = true;
                ButtonText.text = RainbowText;
                SaveColor(0);
            }
        }
        else if (Chinese)
        {
            if (Point1.IsRainbow)
            {
                Point1.IsRainbow = false;
                Point1.IsFire = true;
                ButtonText.text = FireTextChinese;
                SaveColor(1);
            }
            else if (Point1.IsFire)
            {
                Point1.IsFire = false;
                Point1.IsAir = true;
                ButtonText.text = AirTextChinese;
                SaveColor(2);
            }
            else if (Point1.IsAir)
            {
                Point1.IsAir = false;
                Point1.IsEarth = true;
                ButtonText.text = EarthTextChinese;
                SaveColor(3);
            }
            else if (Point1.IsEarth)
            {
                Point1.IsEarth = false;
                Point1.IsWater = true;
                ButtonText.text = WaterTextChinese;
                SaveColor(4);
            }
            else if (Point1.IsWater)
            {
                Point1.IsWater = false;
                Point1.IsAether = true;
                ButtonText.text = AetherTextChinese;
                SaveColor(5);
            }
            else if (Point1.IsAether)
            {
                Point1.IsAether = false;
                Point1.IsDark = true;
                ButtonText.text = ChaosTextChinese;
                SaveColor(6);
            }
            else if (Point1.IsDark)
            {
                Point1.IsDark = false;
                Point1.IsLight = true;
                ButtonText.text = OrderTextChinese;
                SaveColor(7);
            }
            else if (Point1.IsLight)
            {
                Point1.IsLight = false;
                Point1.IsRainbow = true;
                ButtonText.text = RainbowTextChinese;
                SaveColor(0);
            }
        }
        Point1.ColorIndex = ColorIndex1;
        Point2.ColorIndex = ColorIndex2;
    }

    void SaveColor(int Color)
    {
        if (Left)
        {
            PlayerPrefs.SetInt("LeftColor", Color);
        }
        else
        {
            PlayerPrefs.SetInt("RightColor", Color);
        }
    }
}