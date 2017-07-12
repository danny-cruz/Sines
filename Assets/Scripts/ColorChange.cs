using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	public Color StartColor;
	public Color TargetColor;
	public Color[] ColorCycle;
	private Renderer Rend;
	internal Color LerpColor;
	private TrailRenderer TrailRend;
	private Color TrailColor;
	public int ColorIndex;
	private bool Started;
	private Player PlayerPoint;
	private GameObject Point1;
	private Color LerpBlack;
	internal bool Close;
	public Color Alpha;
	internal bool Lost;
	private Controller controller;
	public GameObject ControllerObject;
	private bool Begin;

	// Use this for initialization
	void Start () {
		controller = ControllerObject.GetComponent<Controller>();
		Point1 = GameObject.Find("PlayerSprite1");
		PlayerPoint = Point1.GetComponent<Player>();
		TrailRend = GetComponent<TrailRenderer>();
		LerpColor = StartColor;


	}

	IEnumerator GO (){
		yield return new WaitForSeconds(1.5f);
		Close = true;
	}

	// Update is called once per frame
	void Update () {
		if(!OptionsButton.Pause){
		Begin = controller.Begin;
		Lost = PlayerPoint.Lost;
	
	

		TrailRend.material.SetColor("_Color", LerpColor);
		
		if(Lost){
			StopCoroutine("StartSequence");
			StartCoroutine("GO");
			LerpColor = Color.Lerp(LerpColor, Alpha, Time.deltaTime * 5);

		}

		if(!Lost&&Begin){
			LerpColor = Color.Lerp(LerpColor, TargetColor, Time.deltaTime * 4);
			LerpBlack = LerpColor;
			TrailRend.material.SetColor("_Color", LerpColor);
		if(ColorIndex == 8){
			ColorIndex = 0;
		}

		if(ColorCycle.Length > ColorIndex){
			TargetColor = ColorCycle[ColorIndex];
		}


		


			if(transform.position.x > -.3f && transform.position.x < .3f){
		
			if(!Started){
				StartCoroutine("StartSequence");
			}
		}

			if(transform.position.x < -1.3f || transform.position.x > 1.3f){
			//LerpColor = Color.Lerp(LerpColor, StartColor, Time.deltaTime * .2f);
				Started = false;
			StopCoroutine("StartSequence");
		}
	}
	}
	}

	IEnumerator StartSequence (){
			Started = true;
		ColorIndex +=1;
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("StartSequence");
	}
}
