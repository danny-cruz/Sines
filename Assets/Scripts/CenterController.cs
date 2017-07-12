using UnityEngine;
using System.Collections;

public class CenterController : MonoBehaviour {
	private Vector3 StartPosition;
	public GameObject TangentPoint1;
	public GameObject TangentPoint2;
	private GameObject TargetPoint;
	public float Speed;
	public bool Wait;
	public bool One;
	private float Velocity;
	private float Timer;
	public bool Anchor;
	// Use this for initialization
	void Start () {
		if(One){
			TargetPoint = TangentPoint1;
		}

		if(!One){
			TargetPoint = TangentPoint2;
		}
	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetKey(KeyCode.Space)){

		if(!Anchor){
		if(!Wait){
				transform.position = TargetPoint.transform.position + new Vector3(Mathf.Sin(Time.time * Speed), 0, 0)  ;
		}
			}
	}

		if(!Input.GetButton("Touch")){
			StopCoroutine("Delay");
			transform.position = TargetPoint.transform.position;
			if(Anchor){
			if(!Wait){
				transform.position = TargetPoint.transform.position + new Vector3(Mathf.Sin(Time.time * Speed), 0, 0)  ;
			}
		}
		}

	if(Input.GetButtonDown("Touch")){
		
			StartCoroutine("Delay");
		
		}

	
	}

	IEnumerator Delay (){


	
		transform.position = TargetPoint.transform.position;
		Wait = true;
		yield return new WaitForSeconds(0.0f);
		Wait = false;
	}





}
