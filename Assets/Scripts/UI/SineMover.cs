using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMover : MonoBehaviour {
    public Vector3 ResetPosition;
    public float MaxPosition;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.localPosition.y <= MaxPosition)
        {
            transform.localPosition = ResetPosition;
        }
        else
        {
            transform.localPosition -= Vector3.up * Time.deltaTime;
        }
	}
}
