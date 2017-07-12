using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreText : MonoBehaviour {
	Text text;
	public Color Alpha;
	public Color Gray;
	public float Speed;
	public GameObject ControllerObject;
	private Controller controller;
	public int Score;
	private bool GameOver;
	// Use this for initialization
	void Start () {
		controller = ControllerObject.GetComponent<Controller>();
		text = GetComponent<Text>();

	}
	

	// Update is called once per frame
	void Update () {
		if(controller.Begin){
			text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * Speed);
		}

		if(Controller.Lost){
			text.color = Color.Lerp(text.color, Gray, Time.deltaTime * 2.0f);
		}
		
		
		text.text = "High Score: " + PlayerPrefs.GetInt("highscore", 0);
	}
}
