using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChangeButton : MonoBehaviour
{

    public ColorChange Point1;
    public ColorChange Point2;
    public SineColor Sine0;
    public SineColor Sine1;
    public SineColor Sine2;
    public SineColor Sine3;
    public SineColor Sine4;
    public SineColor Sine5;

    public CircleMask circleMask;
    public CustomizeButton customizeButton;

    public Color Alpha;
    public Color GreyAlpha;
    public Color Grey;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    private Color AlphaLerp;
    private Color WhiteLerp;

    private int OpenSpeed = 10;
    private int CloseSpeed = 30;

    private bool Pressed;

    private SpriteRenderer SpriteRend;
    public Text ButtonText;

    public UI_OptionsButton optionsButton;
    private string RainbowText = "Rainbow";
    private string FireText = "Fire";
    private string AirText = "Air";
    private string EarthText = "Earth";
    private string WaterText = "Water";
    private string AetherText = "Aether";
    private string OrderText = "Order";
    private string ChaosText = "Chaos";

    public int ColorIndex1;
    public int ColorIndex2;

    public bool Left;

    private Vector3 StartScale;
    private Vector3 TargetScale;

    // Use this for initialization
    void Start () {


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
        SpriteRend = GetComponent<SpriteRenderer>();

        StartScale = transform.localScale;
        TargetScale = new Vector3(transform.localScale.x * .9f, transform.localScale.y * .9f, transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!circleMask.Open)
        {
            SpriteRend.color = Alpha;
            ButtonText.color = GreyAlpha;
            ButtonText.enabled = false;
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

            this.gameObject.SetActive(false);
        }
        else if(customizeButton.OpenSubmenu)
        {
            if (circleMask.Open)
            {
                ButtonText.enabled = true;
                ButtonText.color = Color.Lerp(ButtonText.color, Grey, Time.deltaTime * 2);
            }

            if (!Pressed)
            {
                SpriteRend.color = Sine0.LerpColor;
                transform.localScale = Vector3.Lerp(transform.localScale, StartScale, Time.deltaTime * 15);
            }

            if (Pressed)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Time.deltaTime * 15);
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetButtonDown("Touch"))
        {
            Pressed = true;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (Pressed)
            {
                Pressed = false;
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
                Point1.ColorIndex = ColorIndex1;
                Point2.ColorIndex = ColorIndex2;
            }
        }
    }

    void OnMouseExit()
    {
        if (Pressed)
        {
            Pressed = false;
            //SpriteRend.color = ButtonUpColor;
        }
    }

    void SaveColor (int Color)
    {
        if(Left)
        {
            PlayerPrefs.SetInt("LeftColor", Color);
        }
        else
        {
            PlayerPrefs.SetInt("RightColor", Color);
        }    
    }
}
