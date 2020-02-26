using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class HighScoreText : MonoBehaviour {
    public static HighScoreText Instance { get; private set; }
    TextMeshProUGUI text;
    public bool Chinese;
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
        Instance = this;
        controller = ControllerObject.GetComponent<Controller>();
        text = GetComponent<TextMeshProUGUI>();
        myAnimator = GetComponent<Animator>();
        UpdateHighscoreText();
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

        if (!Chinese)
        {
            text.text = "High Score: " + PlayerPrefs.GetInt("highscore");
        }
        else if (Chinese)
        {
            text.text = "高分: " + PlayerPrefs.GetInt("highscore");
        }
	}

    public void UpdateHighscoreText()
    {

        //text.text = "High Score: " + PlayerPrefs.GetInt("highscore");
    }
}
