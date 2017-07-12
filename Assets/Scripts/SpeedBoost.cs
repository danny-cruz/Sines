using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour {
	private GameObject ControllerObject;
	private Controller controller;
	// Use this for initialization
	void Start () {
		ControllerObject = GameObject.Find("Controller");
		controller = ControllerObject.GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Player")){
			controller.SpeedUp = true;

			
		}
	}
}
