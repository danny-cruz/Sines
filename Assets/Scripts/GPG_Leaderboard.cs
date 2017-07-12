using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_Leaderboard : MonoBehaviour {

	private SpriteRenderer SpriteRend;
	public Color Gray;
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
			Pressed = true;
			SpriteRend.color = Gray;
		}

		if(Input.GetButtonUp("Touch")){
			if(SignedIn){
				if(Pressed){
			PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIlu2Nm5MWEAIQBw");
					Pressed = false;
				}
			}
		}
	}

	void OnMouseExit(){
		Pressed = false;
	}
}
