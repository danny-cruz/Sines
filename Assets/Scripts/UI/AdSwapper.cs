using UnityEngine;
using System.Collections;

public class AdSwapper : MonoBehaviour {
	public static bool Show;
	public static bool HideBanner;

	// Use this for initialization
	void Awake () {

	
		if (PlayerPrefs.GetInt("highscore") < 200){
			Show = false;
		
		}
		if (PlayerPrefs.GetInt("highscore") >= 200 && PlayerPrefs.GetInt("highscore") < 5000){
			Show = !Show;
		
		}
		if (PlayerPrefs.GetInt("highscore") >= 5000){
			Show = false;
		
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
