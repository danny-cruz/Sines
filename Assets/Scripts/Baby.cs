using UnityEngine;
using System.Collections;

public class Baby : MonoBehaviour
{
	public float Speed;

	public GameObject Point1;
	public GameObject Point1Baby;
	public GameObject Point2;
	public GameObject Point2Baby;
	public GameObject Point1Target;
	public GameObject Point2Target;

    private Vector3 Point1Start;
    private Vector3 Point2Start;

    private Vector3 TargetScale;
    private Vector3 StartScale;

    private bool Activate;
	private bool Pause;
	private bool Lost;
    private bool Resetting;
    
	// Use this for initialization
	void Start ()
    {
        StartScale = Vector3.zero;
        TargetScale = new Vector3(0.6f, 0.6f, 0.6f);
        Point1Start = Point1.transform.localPosition;
        Point2Start = Point2.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Lost = Controller.Lost;
        Pause = OptionsButton.Pause;

        if (Lost || Pause)
        {
            Resetting = false;
            StopCoroutine("ResetPositions");
            return;
        }

		if(!Pause)
        {
		    if(Activate)
            {   
                if(!Resetting)
                {
                    StartCoroutine("ResetPositions");
                }

			    Point1.transform.position = Vector3.Lerp(Point1.transform.position, Point1Target.transform.position, Time.deltaTime * Speed);
			    Point2.transform.position = Vector3.Lerp(Point2.transform.position, Point2Target.transform.position, Time.deltaTime * Speed);
			
		        if(Vector3.Distance(Point1.transform.position, Point1Target.transform.position) < .5f)
                {
		            Point1Baby.transform.localScale = Vector3.Lerp(Point1Baby.transform.localScale, TargetScale, Time.deltaTime * Speed);
		            Point2Baby.transform.localScale = Vector3.Lerp(Point2Baby.transform.localScale, TargetScale, Time.deltaTime * Speed);
		        }
		    }
	    }
	}
	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag.Equals("Player"))
        {
			Activate = true;
            StartCoroutine("ResetPositions");
		}
	}

    IEnumerator ResetPositions ()
    {
        yield return new WaitForSeconds(5);

        Resetting = true;
        Activate = false;
        Point1.transform.localPosition = Point1Start;
        Point2.transform.localPosition = Point2Start;
        Point1Baby.transform.localScale = StartScale;
        Point2Baby.transform.localScale = StartScale;
    }
}
