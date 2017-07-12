using UnityEngine;
using System.Collections;

public class RotatePoint : MonoBehaviour {
	public bool Begin;
	public float RotateSpeed;
	public float RevertSpeed;
	private Quaternion RoundRot;
	public GameObject Point1;
	public GameObject Point2;
	private Controller Cont;
	public GameObject Contro;
	private Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		Cont = Contro.GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	if(!Cont.Pause){
	if(Cont.Begin){
	if(Begin){
			if(Point1.transform.position.x > -1 || Point1.transform.position.x < 1){
			myTransform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
			}
		}
				if(!Input.GetButton("Touch")&& !Controller.FirstSpin){
		
			myTransform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * RevertSpeed);
		
		}

		if(Input.GetButton("Touch")||Controller.FirstSpin){
			if(!Begin){
			StartCoroutine("Rotate");
				}
		}

	if(!Input.GetButton("Touch")&& !Controller.FirstSpin){



			StopCoroutine("Rotate");
			Begin = false;
			}
		}
	}
	}

	IEnumerator Rotate(){
		yield return new WaitForSeconds(0.0f);
		Begin = true;
	}
}
