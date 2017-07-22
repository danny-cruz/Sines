using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChangeButton : MonoBehaviour
{

    public ColorChange Point1;
    public ColorChange Point2;
    public bool Mirrored;

    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    private Color AlphaLerp;
    private Color WhiteLerp;

    private int OpenSpeed = 10;
    private int CloseSpeed = 30;

    private bool Pressed;

    private SpriteRenderer SpriteRend;
    public Text ButtonText;

    public OptionsButton optionsButton;
    private string RainbowText = "Rainbow";
    private string FireText = "Fire";
    private string AirText = "Air";
    private string EarthText = "Earth";
    private string WaterText = "Water";
    private string AetherText = "Aether";
    private string OrderText = "Order";
    private string ChaosText = "Chaos";

    // Use this for initialization
    void Start () {

        SpriteRend = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!optionsButton.Open)
        {
            AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);

            SpriteRend.color = AlphaLerp;
            ButtonText.color = Alpha;
        }

        else if (!optionsButton.xDelay)
        {
            if (!Pressed)
            {
                WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);

                SpriteRend.color = WhiteLerp;
                ButtonText.color = Color.white;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetButtonDown("Touch"))
        {
            Pressed = true;
            SpriteRend.color = ButtonDownColor;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (Pressed)
            {
                Pressed = false;
                SpriteRend.color = ButtonUpColor;
                Point1.ColorIndex = 0;
                Point2.ColorIndex = 1;

                if (Point1.IsRainbow)
                {
                    Point1.IsRainbow = false;
                    Point1.IsFire = true;
                    ButtonText.text = FireText;

                    if (Mirrored)
                    {
                        Point2.IsRainbow = false;
                        Point2.IsFire = true;
                    }
                }
                else if (Point1.IsFire)
                {
                    Point1.IsFire = false;
                    Point1.IsAir = true;
                    ButtonText.text = AirText;

                    if (Mirrored)
                    {
                        Point2.IsFire = false;
                        Point2.IsAir = true;
                    }
                }
                else if (Point1.IsAir)
                {
                    Point1.IsAir = false;
                    Point1.IsEarth = true;
                    ButtonText.text = EarthText;

                    if (Mirrored)
                    {
                        Point2.IsAir = false;
                        Point2.IsEarth = true;
                    }
                }
                else if (Point1.IsEarth)
                {
                    Point1.IsEarth = false;
                    Point1.IsWater = true;
                    ButtonText.text = WaterText;

                    if (Mirrored)
                    {
                        Point2.IsEarth = false;
                        Point2.IsWater = true;
                    }
                }
                else if (Point1.IsWater)
                {
                    Point1.IsWater = false;
                    Point1.IsAether = true;
                    ButtonText.text = AetherText;

                    if (Mirrored)
                    {
                        Point2.IsWater = false;
                        Point2.IsAether = true;
                    }
                }
                else if (Point1.IsAether)
                {
                    Point1.IsAether = false;
                    Point1.IsLight = true;
                    ButtonText.text = OrderText;

                    if (Mirrored)
                    {
                        Point2.IsAether = false;
                        Point2.IsLight = true;
                    }
                }
                else if (Point1.IsLight)
                {
                    Point1.IsLight = false;
                    Point1.IsDark = true;
                    ButtonText.text = ChaosText;

                    if (Mirrored)
                    {
                        Point2.IsLight = false;
                        Point2.IsDark = true;
                    }
                }
                else if (Point1.IsDark)
                {
                    Point1.IsDark = false;
                    Point1.IsRainbow = true;
                    ButtonText.text = RainbowText;

                    if (Mirrored)
                    {
                        Point2.IsDark = false;
                        Point2.IsRainbow = true;
                    }
                }
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
}
