using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour {

    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public OptionsButton optionsButton;

    private Vector3 OpenTarget1;
    private Vector3 OpenTarget2;
    private Vector3 OpenStart3;

    private Vector3 PointLerp1;
    private Vector3 PointLerp2;
    private Vector3 PointLerp3;
    private Vector3 OpenScale3;
    private Vector3 ClosedScale1;
    private Vector3 ClosedScale3;
    private Vector3 ScaleLerp1;
    private Vector3 ScaleLerp3;
    private LineRenderer Line;

	// Use this for initialization
	void Start () {
        OpenTarget1 = new Vector3(1.1f, 0, 0);
        OpenTarget2 = new Vector3(-1.1f, 0, 0);
        ClosedScale3 = new Vector3(.08f, .08f, 1);
        OpenScale3 = new Vector3(.06f, .06f, 1);
        OpenStart3 = Point3.transform.localPosition;

        PointLerp1 = Point1.transform.localPosition;
        PointLerp2 = Point2.transform.localPosition;
        PointLerp3 = Point3.transform.localPosition;
        ScaleLerp3 = Point1.transform.localScale;

        Line = this.gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        Point1.transform.localPosition = PointLerp1;
        Point2.transform.localPosition = PointLerp2;
        Point3.transform.localPosition = PointLerp3;
        Point1.transform.localScale = ScaleLerp3;
        Point3.transform.localScale = ScaleLerp3;

        if (optionsButton.Open)
        {
            PointLerp3 = Vector3.Lerp(Point3.transform.localPosition, Vector3.zero, Time.deltaTime * 20);
            ScaleLerp3 = Vector3.Lerp(Point3.transform.localScale, OpenScale3, Time.deltaTime * 20);

            if (!optionsButton.XDelay)
            {
                PointLerp1 = Vector3.Lerp(Point1.transform.localPosition, OpenTarget1, Time.deltaTime * 8);
                PointLerp2 = Vector3.Lerp(Point2.transform.localPosition, OpenTarget2, Time.deltaTime * 8);
            }      
        }
        else if (!optionsButton.Open)
        {
            if (optionsButton.XDelay)
            {
                PointLerp1 = Vector3.Lerp(Point1.transform.localPosition, Vector3.zero, Time.deltaTime * 20);
                PointLerp2 = Vector3.Lerp(Point2.transform.localPosition, Vector3.zero, Time.deltaTime * 20);

            }

            if (!optionsButton.shadowDelay)
            {
                
                ScaleLerp3 = Vector3.Lerp(Point3.transform.localScale, ClosedScale3, Time.deltaTime * 20);

                PointLerp3 = Vector3.Lerp(Point3.transform.localPosition, OpenStart3, Time.deltaTime * 20);

            }
        }
        Line.SetPosition(0, Point1.transform.position);
        Line.SetPosition(1, Point2.transform.position);
    }
}
