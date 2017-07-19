using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GPG_Rate : MonoBehaviour
{
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public OptionsButton optionsButton;
    public Text text;
    public SpriteRenderer IconSpriteRend;

    private Color AlphaLerp;
    private Color WhiteLerp;
    private SpriteRenderer SpriteRend;

    private int OpenSpeed = 10;
    private int CloseSpeed = 30;
	private bool Pressed;

	// Use this for initialization
	void Awake ()
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
            IconSpriteRend.color = Alpha;
        }

        else if (!optionsButton.xDelay)
        {
            if (!Pressed)
            {
                WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);

                SpriteRend.color = WhiteLerp;
                text.color = Color.white;
                IconSpriteRend.color = Color.white;
            }
        }
    }
    void OnMouseOver()
    {
	
		if(Input.GetButtonDown("Touch"))
        {	
			Pressed = true;
            SpriteRend.color = ButtonDownColor;
        }

		if(Input.GetButtonUp("Touch"))
        {
			if (Pressed)
            {
				Application.OpenURL ("market://details?id=io.danielcruz.sines");			
				Pressed = false;
                SpriteRend.color = ButtonUpColor;
            }
		}
	}

	void OnMouseExit ()
    {
        if (Pressed)
        {
            Pressed = false;
            //SpriteRend.color = ButtonUpColor;
        }
    }


}
