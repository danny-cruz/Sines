using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class OptionsButton : MonoBehaviour {
	//private bool Open;
    public bool Open;
	public GameObject XButton;
	public GameObject CircleButton;
	public GameObject ShadowButton;
	public GameObject Menu;
	public GameObject TargetPoint;
	public GameObject StartPoint;
    public GameObject ScoreCounter;
    private Shadow ScoreShadow;
    public Color Alpha;
    private Color ShadowColor;
	public float Speed;
	private Quaternion TargetRotation;
	private Quaternion StartRotation;
	public bool Pause;
	public Controller controller;
	public bool FlowLevel;
	public bool ArcadeLevel;
	//public ResetButton NotMode;
	private Vector3 TargetScale;
	private Vector3 StartScale;
	private bool ShadowDelay;
	private SpriteRenderer XButtonSprite;

	public bool XDelay = true;
    public bool xDelay { get { return XDelay; } }
    public bool shadowDelay { get { return ShadowDelay; } }
    private bool HideMe;
	//public Vector3 TargetPosition;
	// Use this for initialization
	void Start ()
    {

        
        //MenuRenderer = Menu.GetComponent<SpriteRenderer>();
        //MenuStartColor = MenuRenderer.color;
        StartScale = new Vector3(CircleButton.transform.localScale.x,CircleButton.transform.localScale.y,CircleButton.transform.localScale.z);
		TargetScale = new Vector3(-35, -35, 1);

		TargetRotation = Quaternion.Euler(0, 0, 0);
		StartRotation = Quaternion.Euler(0, 0, 0);
        Pause = false;
        controller.enabled = true;

        ScoreShadow = ScoreCounter.GetComponent<Shadow>();
        ShadowColor = ScoreShadow.effectColor;
    }

	IEnumerator OnPause(){
		XDelay = true;
		yield return new WaitForSeconds(0.15f);
		XDelay = false;

	}

	IEnumerator OnUnpause(){
		yield return new WaitForSeconds(0.25f);
		XDelay = true;
		yield return new WaitForSeconds(.125f);
		ShadowDelay = false;
		
	}

	IEnumerator Unpause (){
		yield return new WaitForSeconds(.75f);
		Pause = false;
		Open = false;
	
	}



	IEnumerator UnpauseFast (){
		yield return new WaitForSeconds(0.2f);
		Pause = false;
		Open = false;

	
	}
    void OnApplicationPause()
    {
        if (controller.Begin)
        {
            Pause = true;
            Open = true;
            XDelay = false;
            CircleButton.transform.localScale = TargetScale;
            if (!Menu.activeSelf)
            {
                Menu.SetActive(true);
            }
        }
    }
    void OnApplicationFocus()
    {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Open)
            {
                StartCoroutine("OnUnpause");
                if (controller.Begin)
                {
                    StartCoroutine("Unpause");
                }
                if (!controller.Begin)
                {

                    StartCoroutine("UnpauseFast");

                }

            }
            else if (!Open)
            {
                StartCoroutine("OnPause");
            }
            Open = !Open;
        }




        if (Open)
        {
            if (!Menu.activeSelf)
            {
                Menu.SetActive(true);
            }

            StopCoroutine("Unpause");
			Pause = true;
			ShadowDelay = true;
			CircleButton.transform.localScale = Vector3.Lerp(CircleButton.transform.localScale, TargetScale, Time.deltaTime * Speed);
            ScoreShadow.effectColor = Color.Lerp(ScoreShadow.effectColor, Alpha, Time.deltaTime * 4);

			controller.RotateForward = false;

			if(ShadowButton.transform.localScale != Vector3.zero)
            {
				ShadowButton.transform.localScale = Vector3.zero;
			}

		}

		else if(!Open)
        {
            ScoreShadow.effectColor = Color.Lerp(ScoreShadow.effectColor, ShadowColor, Time.deltaTime * 4);
            if (XDelay)
            {

                //XButton.transform.localScale = Vector3.Lerp(XButton.transform.localScale, Vector3.zero, Time.deltaTime * 4f * Speed);
                //XButtonSprite.color = Color.Lerp(XButtonSprite.color, Alpha, Time.deltaTime * 3 * Speed);
                if (Menu.activeSelf)
                {
                    Menu.SetActive(false);
                }
            }

			if(!ShadowDelay){
				ShadowButton.transform.localScale = Vector3.Lerp(ShadowButton.transform.localScale, StartScale, Time.deltaTime * 2f * Speed);
			}
			CircleButton.transform.localScale = Vector3.Lerp(CircleButton.transform.localScale, StartScale, Time.deltaTime * Speed * 2);

			
		}
	}




	void OnMouseOver()
    {
		//controller.DontPlay = true;
		if(Input.GetButtonDown("Touch"))
        {
            OnClick();

        }
	}

    public void OnClick()
    {
        if (Open)
        {
            StartCoroutine("OnUnpause");
            if (controller.Begin)
            {
                StartCoroutine("Unpause");
            }
            if (!controller.Begin)
            {

                StartCoroutine("UnpauseFast");

            }

        }
        else if (!Open)
        {
            StartCoroutine("OnPause");
        }
        Open = !Open;
    }

}
