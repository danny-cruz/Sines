using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class AdSwapper : MonoBehaviour {
	public static bool Show;
	public static bool HideBanner;
    public GPG_SignIn SignInButton;
	// Use this for initialization
	void Awake () {
#if !NO_GPGS
        PlayGamesPlatform.Activate();
        if (PlayerPrefs.GetInt("InitialLogIn") == 0 || PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("LoggedIn", 1);
                    SignInButton.SignIn = true;
                }
                else
                {
                    PlayerPrefs.SetInt("LoggedIn", 0);
                    SignInButton.SignIn = false;
                }
                PlayerPrefs.SetInt("InitialLogIn", 1);
            });
        }
#else
        Application.targetFrameRate = 60;
#endif

        if (PlayerPrefs.GetInt("highscore") < 200){
			Show = false;
		
		}
		if (PlayerPrefs.GetInt("highscore") >= 200 && PlayerPrefs.GetInt("highscore") < 5000){
			Show = !Show;
		
		}
        /*
		if (PlayerPrefs.GetInt("highscore") >= 5000){
			Show = false;
		
		}*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
