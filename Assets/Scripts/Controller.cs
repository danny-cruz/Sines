using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public GameObject Point1;
	public GameObject Point2;
	public GameObject AnchorPoint1;
	public GameObject AnchorPoint2;
	public GameObject CenterPoint1;
	public GameObject CenterPoint2;
	public GameObject TangentPoint1;
	public GameObject TangentPoint2;
	public GameObject MiddlePoint1;
	public GameObject MiddlePoint2;
	public GameObject Blocker1;
	public GameObject Blocker2;

	private ScoreCounter Score;
	public GameObject ScoreCount;
	public bool Swap;
	public float StartSpeed;
	private float Speed;
	private MeshRenderer rend;
	public float MoveSpeed;
	private bool Moving;
	private Vector3 StartPosition1;
	private Vector3 StartPositio2;
	public GameObject Point3;
	public GameObject Point4;
	public float TangentSine;
	private Player PlayerPoint;
	private GameObject PlayPoint;
	internal bool Begin;

	public bool RotateForward;

	//private bool Close;
	public GameObject Fade;
	private Fade Fader;
	public static bool Lost;

	private Vector3 PointPos1;
	private Vector3 PointPos2;
	private Quaternion RotateVector;
	private Quaternion RotateVector2;
	public bool Pause;


	public static bool FirstSpin;
	private float SpeedMod;
	internal bool SpeedUp;

	// Use this for initialization
	void Awake () {
		Lost = false;
		FirstSpin = true;
        Pause = false;
		Fader = Fade.GetComponent<Fade>();
		Score = ScoreCount.GetComponent<ScoreCounter>();
		RotateVector = Quaternion.Euler(0, 0, 125);
		RotateVector2 = Quaternion.Euler(0, 0, -125);
		PlayPoint = GameObject.Find("PlayerSprite1");
		PlayerPoint = PlayPoint.GetComponent<Player>();
		MoveSpeed = 0;
		rend = Point1.GetComponent<MeshRenderer>();
	}


	IEnumerator FirstRot(){
		yield return new WaitForSeconds(.5f);
		FirstSpin = false;
	}
	// Update is called once per frame
	void Update () {
	


		Pause = OptionsButton.Pause;
		if(!Pause){
		PointPos1 = Point1.transform.position;
		PointPos2 = Point2.transform.position;

		if(SpeedUp){
				SpeedMod = 25;
				SpeedUp = false;
			}
	
			if(SpeedMod >0){
				SpeedMod -= 1 * Time.deltaTime * 5;
			}
		Lost = PlayerPoint.Lost;
		

		if(Point1.transform.position.y >=0){
			if(!Begin){
					StartCoroutine("FirstRot");
			Begin = true;
				
					Score.enabled = true;
				Blocker1.SetActive(false);
				Blocker2.SetActive(false);

			}
		}

	
		

		if(!Begin && !Lost){
			if(!Pause){
			if(RotateForward){
					MiddlePoint1.transform.Rotate(Vector3.forward * 3);
					MiddlePoint2.transform.Rotate(Vector3.forward * -3);
				}
			if(!RotateForward){
					MiddlePoint1.transform.localRotation = Quaternion.Slerp(MiddlePoint1.transform.localRotation, Quaternion.Euler(0,0,0), 2 * Time.deltaTime);
					MiddlePoint2.transform.localRotation = Quaternion.Slerp(MiddlePoint2.transform.localRotation, Quaternion.Euler(0,0,0), 2 * Time.deltaTime);
				}
		
			if(Input.GetButtonDown("Touch")){
					RotateForward = true;
			}

			if(Input.GetButtonUp("Touch")){
					RotateForward = false;

			}
				}

		}

		if(Begin && Lost){

				if(Input.GetButtonDown("Touch")){
					Begin = false;
					Fader.FadeAlpha = false;
					Fader.FadeBlack = true;
				}
		}


		if(Lost){
			MoveSpeed = 0;
		}

		if(Begin && !Lost){
			MoveSpeed = 25 + SpeedMod;
		transform.position += Vector3.up * Time.deltaTime * MoveSpeed ;

		if(!Input.GetButton("Touch") && !FirstSpin){
		
			Speed = Mathf.Lerp(Speed, StartSpeed, Time.deltaTime * 3);
			CenterPoint1.transform.position = Vector3.Lerp(CenterPoint1.transform.position, AnchorPoint2.transform.position, Time.deltaTime * Speed * 1.5f);
			CenterPoint2.transform.position = Vector3.Lerp(CenterPoint2.transform.position, AnchorPoint1.transform.position, Time.deltaTime * Speed * 1.5f);

		}
	
		Point1.transform.position = Vector3.Lerp(Point1.transform.position, CenterPoint1.transform.position, Time.deltaTime * Speed);
		Point2.transform.position = Vector3.Lerp(Point2.transform.position, CenterPoint2.transform.position, Time.deltaTime * Speed);


		if(Input.GetButton("Touch")||FirstSpin){

			TangentSine  = Mathf.PingPong(Time.time* .2f, .8f);
			Speed = Mathf.Lerp(Speed, StartSpeed, Time.deltaTime * 12);
			CenterPoint1.transform.position = Vector3.Lerp(CenterPoint1.transform.position, TangentPoint1.transform.position, Time.deltaTime * Speed);
			CenterPoint2.transform.position = Vector3.Lerp(CenterPoint2.transform.position, TangentPoint2.transform.position, Time.deltaTime * Speed);
		
		}
		if(Input.GetButtonUp("Touch") &&!FirstSpin){
			Speed = StartSpeed;
		

			}
		}
	
	}
	}



}
