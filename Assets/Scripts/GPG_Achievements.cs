using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_Achievements : MonoBehaviour {
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

		SignedIn = GPG_SignIn.SignIn;

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
			if(SignedIn){
			Social.ShowAchievementsUI();
					Pressed = false;
				}
			}
		}
	}

	void OnMouseExit (){
		Pressed = false;
	}
}
