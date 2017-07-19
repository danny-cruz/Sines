using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFadeIn : MonoBehaviour {
	private Text text;
	public Color White;
	public Color Alpha;
    public Controller controller;
    public OptionsButton optionsButton;
	public float Speed;
	private bool FadeIn = false;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
        StartCoroutine("Delay");
    }

	IEnumerator Delay (){
		yield return new WaitForSeconds(.5f);
		FadeIn = true;
	}

	// Update is called once per frame
	void Update ()
    {
        if (optionsButton.Open)
        {
            text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * 10.0f);
        }
        else if (!optionsButton.Open)
        {
            if (FadeIn)
            {
                text.color = Color.Lerp(text.color, White, Time.deltaTime * Speed * .2f);
            }
            if (!FadeIn)
            {
                text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * Speed);
            }



            if (!controller.Begin && !Controller.Lost)
            {
                if (Input.GetButtonDown("Touch"))
                {
                    FadeIn = false;
                    StopCoroutine("Delay");

                }
                if (Input.GetButtonUp("Touch"))
                {
                    StartCoroutine("Delay");
                }
            }

            if (controller.Begin)
            {
                StopCoroutine("Delay");
                text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * Speed);
                if (text.color == Alpha)
                {
                    gameObject.SetActive(false);
                }
            }
        }
	}
}
