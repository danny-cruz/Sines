using UnityEngine;
using System.Collections;

public class Radiate : MonoBehaviour {

	private bool Lost;
	private Vector3 TargetScale;
	private Vector3 StartScale;
	public float Speed;
	// Use this for initialization
	void Start () {
		StartScale = transform.localScale;
	

		TargetScale =  new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		Lost = Controller.Lost;
		if(Lost){
			transform.localScale = Vector3.Lerp(transform.localScale, TargetScale,  Time.deltaTime * Speed);
		}
	}
}
