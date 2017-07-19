using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_Achievements : MonoBehaviour
{
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public Color AlphaGrey;
    public Color Grey;
    public OptionsButton optionsButton;
    public GPG_SignIn GPG_signIn;
    public Text text;
    public SpriteRenderer IconSpriteRend;

    private Color AlphaLerp;
    private Color WhiteLerp;

    private int OpenSpeed = 10;
    private int CloseSpeed = 30;

    private SpriteRenderer SpriteRend;
	private bool Pressed;

	// Use this for initialization
	void Awake ()
    {
		SpriteRend = GetComponent<SpriteRenderer>();
        
        if(GPG_signIn.SignIn)
        {
            SpriteRend.color = Alpha;
        }
        else
            SpriteRend.color = AlphaGrey;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!optionsButton.Open)
        {
            if (GPG_signIn.SignIn)
            {
                AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);
            }
            else if (!GPG_signIn.SignIn)
            {
                AlphaLerp = Color.Lerp(SpriteRend.color, AlphaGrey, Time.deltaTime * CloseSpeed);
            }

            SpriteRend.color = AlphaLerp;
            text.color = Alpha;
            IconSpriteRend.color = Alpha;
        }

        else if (!optionsButton.xDelay)
        {
            if (!Pressed)
            {
                if (GPG_signIn.SignIn)
                {
                    WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);
                }
                else if (!GPG_signIn.SignIn)
                {
                    WhiteLerp = Color.Lerp(SpriteRend.color, Grey, Time.deltaTime * OpenSpeed);
                }

                SpriteRend.color = WhiteLerp;
                text.color = Color.white;
                IconSpriteRend.color = Color.white;
            }
        }

    }
	
	void OnMouseOver()
    {
        if (!GPG_signIn.SignIn)
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
			if(Pressed)
            {
			    if (GPG_signIn.SignIn)
                {
			        Social.ShowAchievementsUI();
				    Pressed = false;
                    SpriteRend.color = ButtonUpColor;
                }
			}
		}
	}

    void OnMouseExit()
    {
        if (Pressed)
        {
            Pressed = false;   
        }

    }
}
