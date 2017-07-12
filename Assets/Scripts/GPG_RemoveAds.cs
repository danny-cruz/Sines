using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GPG_RemoveAds : MonoBehaviour {
	public Color Gray;
	private SpriteRenderer SpriteRend;
	private bool SignedIn;
	private bool Pressed;
	// Use this for initialization
	void Start () {
	
		SpriteRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

	

		if(Input.GetButtonUp("Touch")){
			SpriteRend.color = Color.white;
		}
	}
	
	void OnMouseOver(){
	
		if(Input.GetButtonDown("Touch")){
			SpriteRend.color = Gray;
			Pressed = true;
		}

		if(Input.GetButtonUp("Touch")){
			if(Pressed){
				Application.OpenURL ("market://details?id=io.danielcruz.looper");
			
					Pressed = false;
				
			}
		}
	}

	void OnMouseExit (){
		Pressed = false;
	}


}
