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
    public GPGButton gpgButton;

    private int OpenSpeed = 5;
    private int CloseSpeed = 30;
	private bool Pressed;

	// Use this for initialization
	void Awake ()
    {
		SpriteRend = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {

        if (!gpgButton.OpenSubmenu)
        {
            AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);

            SpriteRend.color = Alpha;
            text.color = Alpha;
            IconSpriteRend.color = Alpha;
            this.gameObject.SetActive(false);
        }

        else if (!optionsButton.xDelay && gpgButton.OpenSubmenu)
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
        if (!gpgButton.OpenSubmenu)
        {
            return;
        }

        if (Input.GetButtonDown("Touch"))
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
