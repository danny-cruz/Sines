using UnityEngine;
using System.Collections;

public class TextFade : MonoBehaviour {
	private SpriteRenderer text;
	public Color White;
	public Color Alpha;
	public GameObject ControllerObject;
	private Controller controller;
	public float Speed;
	private bool Fade = true;
	// Use this for initialization
	void Start () {
		text = GetComponent<SpriteRenderer>();
		controller = ControllerObject.GetComponent<Controller>();
	}

	IEnumerator Delay (){
		yield return new WaitForSeconds(.50f);
		Fade = true;
	}

	// Update is called once per frame
	void Update () {

	if(!controller.Begin && !Controller.Lost && !OptionsButton.Pause){
	if(Input.GetButtonDown("Touch")){
				Fade = false;
				StopCoroutine("Delay");
			
		}
	if(Input.GetButtonUp("Touch")){
				StartCoroutine("Delay");
		}

			if(!Fade){
				text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * Speed);
			}
			if(Fade){

					text.color = Color.Lerp(text.color, White, Time.deltaTime * Speed * .5f);
				
				
			}
		}
	if(controller.Begin){
			StopCoroutine("Delay");
			text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * Speed);
			if(text.color == Alpha){
				gameObject.SetActive(false);
			}
		}
	}
}
