using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
	private bool Pressed;
	public Color Gray;
	public Color White;
	public Color Alpha;
	private SpriteRenderer SpriteRend;
	public bool Active;
	public SpriteRenderer Baby;
	public float Speed;
	public bool Flow;
	public GameMode Partner;
	public GameObject FirstLevel;
	public GameObject Sprite1;
	public GameObject Sprite2;
	public GameObject Counter;
	public static bool FlowActive;
	public OptionsButton Options;
	public Fade Fader;
	public Controller controller;
	// Use this for initialization
	void Start () {
		controller.enabled = true;
		
		SpriteRend = GetComponent<SpriteRenderer>();
		if(FlowActive){
			if(Flow){
				Baby.color = White;
				Active = true;
				Partner.Active = false;
				Options.FlowLevel = true;
				Deactivate();
		
			}

			
		}

		if(!FlowActive){
			if(Flow){
				Partner.Baby.color = White;
			}
			Options.ArcadeLevel = true;
		}
		if(Active){

		}
	}

	
	// Update is called once per frame
	void Update () {

	

		if(Input.GetButtonUp("Touch")){
			SpriteRend.color = Color.white;
		}

		if(Flow){
			FlowActive = Active;
		}

		if(!Pressed){
		if(Active){
			if(Baby.color != White){
				Baby.color = Color.Lerp(Baby.color, White, Time.deltaTime * Speed);

			}
		}

		if(!Active){
			if(Baby.color != Alpha){
				Baby.color = Color.Lerp(Baby.color, Alpha, Time.deltaTime * Speed * 3);

			}
		}
		}
	}

	void Deactivate(){
		FirstLevel.SetActive(false);
		Sprite1.SetActive(false);
		Sprite2.SetActive(false);
		Counter.SetActive(false);
	}

	void Activate(){
		FirstLevel.SetActive(true);
		Sprite1.SetActive(true);
		Sprite2.SetActive(true);
		Counter.SetActive(true);
	}

	void OnMouseOver(){
		
		if(Input.GetButtonDown("Touch")){
			if(!Active){
			SpriteRend.color = Gray;
			}
			if(Active){
				Baby.color = Gray;
			}
			Pressed = true;
		}
		
		if(Input.GetButtonUp("Touch")){
			if(Pressed){
				if(Partner.Active){
					Partner.Active = false;
					Active = true;
					if(controller.Begin){
					Application.LoadLevel(0);
					}

					if(Controller.Lost){
						Application.LoadLevel(0);
					}
					if(!controller.Begin){
						if(Flow){
						Deactivate();
						}
						if(!Flow){
							Activate();
						}
					}
				}

					Pressed = false;
				
			}
		}
	}


	
	void OnMouseExit (){
		Pressed = false;
	}
}
