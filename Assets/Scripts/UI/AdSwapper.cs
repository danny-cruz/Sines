using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class AdSwapper : MonoBehaviour {
	public static bool Show;
	public static bool HideBanner;
    public bool AdFree;
	// Use this for initialization
	void Awake () {

#if NO_GPGS

        
#else
        Application.targetFrameRate = 60;
#endif
        if (AdFree)
        {
            return;
        }
        if (PlayerPrefs.GetInt("highscore") < 150)
        {
            Show = false;

        }
        else if (PlayerPrefs.GetInt("highscore") >= 150)
        {
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
