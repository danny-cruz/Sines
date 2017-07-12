using UnityEngine;
using System.Collections;

public class Baby : MonoBehaviour {
	public GameObject Parent;
	public float Speed;
	public GameObject Point1;
	public GameObject Point1Baby;
	public GameObject Point2;
	public GameObject Point2Baby;
	public GameObject Point1Target;
	public GameObject Point2Target;
	private bool Activate;
	public Vector3 TargetScale;
	private bool Pause;
	private bool Lost;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Lost = Controller.Lost;
		Pause = OptionsButton.Pause;
		if(!Pause && !Lost){
		if(Activate){
			Point1.transform.position = Vector3.Lerp(Point1.transform.position, Point1Target.transform.position, Time.deltaTime * Speed);
			Point2.transform.position = Vector3.Lerp(Point2.transform.position, Point2Target.transform.position, Time.deltaTime * Speed);
			
		if(Vector3.Distance(Point1.transform.position, Point1Target.transform.position) < .5f){
					Point1Baby.transform.localScale = Vector3.Lerp(Point1Baby.transform.localScale, TargetScale, Time.deltaTime * Speed);
					Point2Baby.transform.localScale = Vector3.Lerp(Point2Baby.transform.localScale, TargetScale, Time.deltaTime * Speed);

				}
		}
	}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Player")){
			Activate = true;
		
		}
	}
}
