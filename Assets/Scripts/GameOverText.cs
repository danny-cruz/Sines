using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GameOverText : MonoBehaviour {
	private bool Fade;
	private bool Fade2;
	private InterstitialAd interstitial; 
	private bool AdShowing;
	private bool IsOn;
	private bool BannerOn;
	public Color Gray;
	Text text;
	private bool Lost;



	// Use this for initialization
	void Start () {

		interstitial = new InterstitialAd("ca-app-pub-5851146300950261/9743770233");
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		
		// Load the interstitial with the request.
	
		text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {


			
		Lost = Controller.Lost;


			
		if(Lost){
			StartCoroutine("FadeIn");
		}
	

	

		if(Fade){
			text.color = Color.Lerp(text.color, Color.white, Time.deltaTime * 2.0f);
		
			if(Input.GetButtonDown("Touch")){
				if(AdSwapper.Show){
			if (interstitial.IsLoaded()) {
				interstitial.Show();
					
			
					}
				}
				if(!OptionsButton.Pause){
					Application.LoadLevel(0);
				}
			
		
			}
		}
	}

	IEnumerator FadeIn (){
		yield return new WaitForSeconds(1);
		Fade = true;
	}


	
}
