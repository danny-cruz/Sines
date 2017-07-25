using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMover : MonoBehaviour {
    public Vector3 ResetPosition;
    public float MaxPosition;
    public GameObject Sine;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.localPosition.y <= MaxPosition)
        {
            transform.localPosition = new Vector3 (Sine.transform.localPosition.x, Sine.transform.localPosition.y + 1.396f, -15);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
	}
}
