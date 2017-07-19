using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour {
	public bool Fade;

	private InterstitialAd interstitial; 
	private bool AdShowing;
	private bool IsOn;
	private bool BannerOn;
    public Color Alpha;
    public Color Gray;
	private Text text;
	public bool Lost;
    public bool GameOver;
    public Controller controller;
    private bool FadeStart;
    public float Speed;
    public OptionsButton optionsButton;


	// Use this for initialization
	void Awake () {

		interstitial = new InterstitialAd("ca-app-pub-5851146300950261/9743770233");
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		
		// Load the interstitial with the request.
	
		text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update ()
    {


			
		Lost = Controller.Lost;


			
		if(Lost && !FadeStart)
        {
			StartCoroutine("TextFadeIn");
		}
	

	

		if(Fade)
        {
            if (!GameOver)
            {
                if (optionsButton.Open)
                {
                    text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * 15.0f);
                }
                else if (optionsButton.XDelay)
                {
                    if (text.color != Gray)
                    {
                        text.color = Color.Lerp(text.color, Gray, Time.deltaTime * Speed);
                    }
                }
               
            }

            if (Input.GetButtonDown("Touch"))
            {
                if (!OptionsButton.Pause)
                {            
                    StartCoroutine("BackgroundFadeDelay");   
                }
            }
		}
	}

	IEnumerator TextFadeIn ()
    {
        FadeStart = true;
        yield return new WaitForSeconds(1);
		Fade = true;
    }
    public IEnumerator BackgroundFadeDelay ()
    {
        GameOver = true;
        Fade = true;
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        if (AdSwapper.Show)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }
        

    }
}
