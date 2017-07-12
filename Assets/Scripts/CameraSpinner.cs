using UnityEngine;
using System.Collections;

public class CameraSpinner : MonoBehaviour {
	public float Length;
	private bool SpinLeft;
	private bool SpinRight;
	public static bool RightStart;
	private Camera MainCam;
	public float Speed;
	private float RotSpeed;
	public float SecondModifier;
	private bool Pause;
	// Use this for initialization
	void Start () {
		RotSpeed = 0;
		MainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Pause = OptionsButton.Pause;
		if(!Controller.Lost){
			if(!Pause){
		MainCam.transform.Rotate(Vector3.forward * RotSpeed);

		if(SpinRight){
			RotSpeed = Mathf.Lerp(RotSpeed, Speed, Time.deltaTime);
		}

		if(SpinLeft){
			RotSpeed = Mathf.Lerp(RotSpeed, -Speed, Time.deltaTime);
		}

		if(!SpinLeft && !SpinRight){
			RotSpeed =0;
			MainCam.transform.rotation = Quaternion.Lerp(MainCam.transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * Speed * 2);
		}
		}
		}
	}

	IEnumerator RotateCam (){
		SpinRight = true;
		yield return new WaitForSeconds(Length);
		SpinRight = false;
		SpinLeft = true;
		yield return new WaitForSeconds(Length);
		SpinLeft = false;
	}

	IEnumerator RotateCam2 (){
		SpinLeft = true;
		yield return new WaitForSeconds(Length);
		SpinLeft = false;
		SpinRight = true;
		yield return new WaitForSeconds(Length);
		SpinRight = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Player")){

			transform.position = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
			if(RightStart){
			StartCoroutine("RotateCam");
			}

			if(!RightStart){
				StartCoroutine("RotateCam2");
			}
			RightStart = !RightStart;
			
		}
	}
}
