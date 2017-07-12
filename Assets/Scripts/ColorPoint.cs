using UnityEngine;
using System.Collections;

public class ColorPoint : MonoBehaviour {
	private Renderer Rend;
	private GameObject Point;
	public bool One;
	// Use this for initialization
	void Start () {

		if(One){
			Point = GameObject.Find("Point1");
		}

		if(!One){
			Point = GameObject.Find("Point2");
		}

	}
	
	// Update is called once per frame
	void Update () {
		Rend = Point.GetComponent<Renderer>();
		GetComponent<Renderer>().material.SetColor("_Color", Rend.material.color);
	}
}
