using UnityEngine;
using System.Collections;

public class BabyLine : MonoBehaviour {
	private LineRenderer Line;
	public GameObject TargetPoint;
	private Transform myTransform;
	// Use this for initialization
	void OnEnable () {
		Line = GetComponent<LineRenderer>();
		myTransform = transform;
	
	}

	void Update () {
		Line.SetPosition(0, myTransform.position);
		Line.SetPosition(1, TargetPoint.transform.position);
	
	}
}
