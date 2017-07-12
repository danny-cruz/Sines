using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_SignIn : MonoBehaviour {
	private SpriteRenderer SignedIn;
	private SpriteRenderer SignedOut;
	private SpriteRenderer AchieveOut;
	private SpriteRenderer LeaderOut;


	public GameObject SignInObject;
	public GameObject SignOutObject;
	public GameObject AchieveButtonOut;
	public GameObject LeaderboardOut;
	public float Speed;

	public Color White;
	public Color Alpha;
	public static bool SignIn;
	public int StaySignedIn;
	private SpriteRenderer SpriteRend;
	public Color Gray;
	private bool Pressed;
	// Use this for initialization
	void Awake () {
		PlayGamesPlatform.Activate();
		//SpriteRend = GetComponent<SpriteRenderer>();

		if(PlayerPrefs.GetInt("LoggedIn") == 1){
			SignIn = true;
			Social.localUser.Authenticate((bool success) => {
				
				
			});
		}
		SignedIn = SignInObject.GetComponent<SpriteRenderer>();
		SignedOut = SignOutObject.GetComponent<SpriteRenderer>();
		AchieveOut = AchieveButtonOut.GetComponent<SpriteRenderer>();
		LeaderOut = LeaderboardOut.GetComponent<SpriteRenderer>();

		if(SignIn){
			SignedIn.color = Alpha;
			SignedOut.color = White;
		}
		
		if(!SignIn){
			SignedIn.color = Alpha;
			SignedOut.color = White;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Z)){
			SignIn = true;
		
		}

		if(Input.GetKeyDown(KeyCode.X)){
			SignIn = false;
			
		}
	if(!Pressed){
	if(SignIn){
			if(SignedIn.color != White){
				SignedIn.color = Color.Lerp(SignedIn.color, White, Time.deltaTime * Speed);
			}
			if(SignedOut.color != Alpha){
				SignedOut.color = Color.Lerp(SignedOut.color, Alpha, Time.deltaTime * Speed * 6);
			
			}
			if(LeaderOut.color != Alpha){
				LeaderOut.color = Color.Lerp(LeaderOut.color, Alpha, Time.deltaTime * 2.5f);
			AchieveOut.color = Color.Lerp(AchieveOut.color, Alpha, Time.deltaTime * 2.5f);
			}

		}
		if(!SignIn){

		if(SignedIn.color != Alpha){
			SignedIn.color = Color.Lerp(SignedIn.color, Alpha, Time.deltaTime * Speed * 6	);
		}
		if(SignedOut.color != White){
			SignedOut.color = Color.Lerp(SignedOut.color, White, Time.deltaTime * Speed);

		}
			if(LeaderOut.color != White){
				LeaderOut.color = Color.Lerp(LeaderOut.color, White, Time.deltaTime * Speed);
				AchieveOut.color = Color.Lerp(AchieveOut.color, White, Time.deltaTime * Speed);
			}
		}
		}
	}

	void OnMouseExit(){
		Pressed = false;
	}

	void OnMouseOver(){

		if(Input.GetButtonDown("Touch")){

			Pressed = true;
			if(!SignIn){
				SignedOut.color = Gray;
			}

			if(SignIn){
				SignedIn.color = Gray;
			}
		}

		if(Input.GetButtonUp("Touch")){

			if(Pressed){

			if(!SignIn){
				//SignedIn.color = White;
			Social.localUser.Authenticate((bool success) => {
				if(success){
						SignIn = true;
						PlayerPrefs.SetInt("LoggedIn", 1);
				}
				else{
					Debug.Log("Failed");
				}
			});
			}
			if(SignIn){
				//SignedOut.color = White;
				PlayGamesPlatform.Instance.SignOut();
				SignIn = false;
				PlayerPrefs.SetInt("LoggedIn", 0);
				}
				Pressed = false;
			}
		}
	}
}
