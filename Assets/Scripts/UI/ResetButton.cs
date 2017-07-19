using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour {
	
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public Color Grey;
    public OptionsButton optionsButton;
    public Text text;
    private SpriteRenderer SpriteRend;
    private InterstitialAd interstitial;
    public GameOverText GameOver;
    public Controller controller;
    private Color AlphaLerp;
    private Color WhiteLerp;
    private int OpenSpeed = 10;
    private int CloseSpeed = 30;
    private bool Pressed;
	public Fade Fader;
	// Use this for initialization
	void Awake ()
    {
		SpriteRend = GetComponent<SpriteRenderer>();
    }

	
	// Update is called once per frame
	void Update ()
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
                text.color = Grey;
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
                GameOver.StartCoroutine("BackgroundFadeDelay");

            }
            
        }
				
	}
	
	void OnMouseExit ()
    {
		Pressed = false;
	}
}
