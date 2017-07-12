using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class GameOver2 : MonoBehaviour {
	private bool Fade;
	private bool Fade2;

	public Color Gray;
	Text text;
	public Text text2;
	private bool Lost;
	
	
	
	// Use this for initialization
	void Start () {

		// Load the interstitial with the request.
		
		text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		Lost = Controller.Lost;
		
		
		
		if(Lost){
			StartCoroutine("FadeIn");
			
			
			
		}
		
		
		if(Fade2){
			text2.color = Color.Lerp(text2.color, Gray, Time.deltaTime);
		}
		
		if(Fade){
			text.color = Color.Lerp(text.color, Color.white, Time.deltaTime * 2.0f);
			
			if(Input.GetButtonDown("Touch")){

				if(!OptionsButton.Pause){
					Application.LoadLevel(0);
				}
				
				
			}
		}
	}
	
	IEnumerator FadeIn (){
		yield return new WaitForSeconds(1);
		Fade = true;
		yield return new WaitForSeconds(.5f);
		Fade2 = true;
		
		
	}
	
	
	
}
