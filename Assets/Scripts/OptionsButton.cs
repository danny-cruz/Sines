using UnityEngine;
using System.Collections;


public class OptionsButton : MonoBehaviour {
	public static bool Open;
	public GameObject Ellipsis;
	public GameObject XButton;
	public GameObject CircleButton;
	public GameObject ShadowButton;
	public GameObject Menu;
	public GameObject TargetPoint;
	public GameObject StartPoint;
	public float Speed;
	private Quaternion TargetRotation;
	private Quaternion StartRotation;
	public static bool Pause;
	private Controller controller;
	public GameObject ControllerObject;
	public bool FlowLevel;
	public bool ArcadeLevel;
	public GameMode NotMode;
	private Vector3 TargetScale;
	private Vector3 StartScale;
	private bool ShadowDelay;
	private SpriteRenderer MenuRenderer;
	private Color MenuStartColor;

	public bool XDelay = true;

	private bool HideMe;
	//public Vector3 TargetPosition;
	// Use this for initialization
	void Start () {

		MenuRenderer = Menu.GetComponent<SpriteRenderer>();
		MenuStartColor = MenuRenderer.color;
		StartScale = new Vector3(CircleButton.transform.localScale.x,CircleButton.transform.localScale.y,CircleButton.transform.localScale.z);
		TargetScale = new Vector3(-35, -35, 1);

		TargetRotation = Quaternion.Euler(0, 0, 0);
		StartRotation = Quaternion.Euler(0, 0, 0);
		controller = ControllerObject.GetComponent<Controller>();

		
	

			

	

	}

	IEnumerator OnPause(){
		XDelay = true;
		yield return new WaitForSeconds(0.15f);
		XDelay = false;

	}

	IEnumerator OnUnpause(){
		yield return new WaitForSeconds(0.25f);
		XDelay = true;
		yield return new WaitForSeconds(.15f);
		ShadowDelay = false;
		
	}

	IEnumerator Unpause (){
		yield return new WaitForSeconds(1);
		Pause = false;
		Open = false;
	
	}



	IEnumerator UnpauseFast (){
		yield return new WaitForSeconds(0.2f);
		Pause = false;
		Open = false;

	
	}
	// Update is called once per frame
	void Update () {

	

		if (!Open){
			MenuRenderer.color = Color.Lerp(MenuRenderer.color, MenuStartColor, Time.deltaTime * 15);
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			if(Open){
				
				
				
				
				if(controller.Begin){
					StartCoroutine("Unpause");
				}
				if(!controller.Begin){
					
					StartCoroutine("UnpauseFast");
				}
				Open = false;
			}

		
			if(!Open){
				StartCoroutine("OnPause");
			}


			Open = !Open;
		}



	
		if(Open){
			StopCoroutine("Unpause");
			Pause = true;
			ShadowDelay = true;
			CircleButton.transform.localScale = Vector3.Lerp(CircleButton.transform.localScale, TargetScale, Time.deltaTime * Speed);

			controller.RotateForward = false;

			if(Ellipsis.transform.localScale != Vector3.zero){
			Ellipsis.transform.localScale = Vector3.Lerp(Ellipsis.transform.localScale, Vector3.zero, Time.deltaTime * 2f * Speed);
				ShadowButton.transform.localScale = Vector3.zero;
			}

			if(!XDelay){
				XButton.transform.localScale = Vector3.Lerp(XButton.transform.localScale, new Vector3(1,1,1), Time.deltaTime * 2f * Speed);
				MenuRenderer.color = Color.Lerp(MenuRenderer.color, Color.white, Time.deltaTime * 5);
			}

		


		}

		if(!Open){
			if(XDelay){
				XButton.transform.localScale = Vector3.Lerp(XButton.transform.localScale, Vector3.zero, Time.deltaTime * 2f * Speed);

			}

			if(!ShadowDelay){
				Ellipsis.transform.localScale = Vector3.Lerp(Ellipsis.transform.localScale, new Vector3(1,1,1), Time.deltaTime * 2f * Speed);
				ShadowButton.transform.localScale = Vector3.Lerp(ShadowButton.transform.localScale, StartScale, Time.deltaTime * 2f * Speed);
			}
			CircleButton.transform.localScale = Vector3.Lerp(CircleButton.transform.localScale, StartScale, Time.deltaTime * Speed * 2);

			Ellipsis.transform.localRotation = Quaternion.Lerp(Ellipsis.transform.localRotation, StartRotation, Time.deltaTime * Speed);
		}
	}




	void OnMouseOver(){
		//controller.DontPlay = true;
		if(Input.GetButtonDown("Touch")){
			if(Open){

			
					StartCoroutine("OnUnpause");
				

				if(controller.Begin){
				StartCoroutine("Unpause");
				}
				if(!controller.Begin){

					StartCoroutine("UnpauseFast");
				
			}

		}

			if(!Open){
				StartCoroutine("OnPause");
			}
		


			Open = !Open;
		}
	}

}
