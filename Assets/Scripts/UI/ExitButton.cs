using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitButton : MonoBehaviour
{

    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public OptionsButton optionsButton;
    public Text text;


    private Color AlphaLerp;
    private Color WhiteLerp;
    private SpriteRenderer SpriteRend;

    private int OpenSpeed = 10;
    private int CloseSpeed = 30;
    private bool Pressed;

    // Use this for initialization
    void Start()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (!optionsButton.Open)
        {
            AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);

            SpriteRend.color = AlphaLerp;
            text.color = Alpha;
        }

        else if (!optionsButton.xDelay)
        {
            if (!Pressed)
            {
                WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);

                SpriteRend.color = WhiteLerp;
                text.color = Color.white;
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
                Application.Quit();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
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