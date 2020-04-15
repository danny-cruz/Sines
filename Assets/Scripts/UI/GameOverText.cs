using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api.Mediation.AppLovin;

public class GameOverText : MonoBehaviour {


    public bool CHINABUILD;
    public bool AcceptedTerms;
    public bool Fade;
	private InterstitialAd interstitial;
    //unityAds
    public string placementId = "interstitial";
    public string gameId = "3429659";
    private bool AdShowing;
	private bool IsOn;
	private bool BannerOn;
    public Color Alpha;
    public Color Gray;
	private TextMeshProUGUI text;
	public bool Lost;
    public bool GameOver;
    public Controller controller;
    private bool FadeStart;
    public float Speed;
    public UI_OptionsButton optionsButton;
    public Fade Fader;

	// Use this for initialization
	void Awake () {

        /*
        if (PlayerPrefs.GetInt("AcceptedTerms") == 0)
        {
            SceneManager.LoadScene("Terms China", LoadSceneMode.Single);
        }
        */

        interstitial = new InterstitialAd("ca-app-pub-5851146300950261/9167429037");
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);

        AppLovin.Initialize();



        text = GetComponent<TextMeshProUGUI>();

	}

    void Start()
    {   

    }

    // Update is called once per frame
    void Update ()
    {
        Lost = Controller.Lost;
			
		if(Lost && !FadeStart)
        {
            text.enabled = true;
			StartCoroutine("TextFadeIn");
            optionsButton.enabled = false;

        }
	
		if(Fade)
        {
            Fader.FadeBlack = true;
            if (!GameOver)
            {
                if (optionsButton.Open)
                {
                    text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * 15.0f);
                }
                else if (optionsButton.xDelay)
                {
                    if (text.color != Gray)
                    {
                        text.color = Color.Lerp(text.color, Gray, Time.deltaTime * Speed);
                    }
                }
               
            }

            if (Input.GetButtonDown("Touch"))
            {
                if (!UI_OptionsButton.Pause)
                {            
                    StartCoroutine("BackgroundFadeDelay");   
                }
            }
		}
	}
    /*
    IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(1);
        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
        }
        else { StartCoroutine(ShowAd()); }
    }
    */
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
#if !NO_GPGS
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        if (AdSwapper.Show)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }
#elif NO_GPGS

        

        // unityAds
        /*
        if (CHINABUILD)
        {
            SceneManager.LoadScene("Android China", LoadSceneMode.Single);
            if (AdSwapper.Show)
            {
                Debug.Log("HEY");
                if (Advertisement.IsReady(placementId))
                {
                    Advertisement.Show(placementId);
                }
                else { StartCoroutine(ShowAd()); }
            }
        }
        */
        // admob
        if (!CHINABUILD)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            if (AdSwapper.Show)
            {
                if (interstitial.IsLoaded())
                {
                    interstitial.Show();
                }
            }
        }
        
#elif UNITY_IOS
		SceneManager.LoadScene("iOS", LoadSceneMode.Single);
         if (AdSwapper.Show)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }
#endif



    }


}
