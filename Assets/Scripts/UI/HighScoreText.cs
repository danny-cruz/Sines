using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HighScoreText : MonoBehaviour {
    TextMeshProUGUI text;
	public Color Alpha;
	public Color Gray;
	public float Speed;
	public GameObject ControllerObject;
	private Controller controller;
	public int Score;
    public GameOverText GameOver;
    public UI_OptionsButton optionsButton;
    private Animator myAnimator;
	// Use this for initialization
	void Start ()
    {
		controller = ControllerObject.GetComponent<Controller>();
        text = GetComponent<TextMeshProUGUI>();
        myAnimator = GetComponent<Animator>();
    }
	

	// Update is called once per frame
	void Update ()
    {
        /*
        if (GameOver.Fade)
        {
            if (text.color != Gray)
            {
                text.color = Color.Lerp(text.color, Gray, Time.deltaTime * 1.0f);
            }
        }
        else if (controller.Begin)
        {
            if (!optionsButton.Open)
            {
                if (text.color != Alpha)
                {
                    text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * Speed * 2);
                }
            }
            else if (optionsButton.Open)
            {
              // myAnimator.Play("FadeIn");
            }
		}
        */
        if (GameOver.Fade)
        {
            myAnimator.SetTrigger("Lost");
        }

        text.text = "High Score: " + PlayerPrefs.GetInt("highscore", 0);
	}
}
