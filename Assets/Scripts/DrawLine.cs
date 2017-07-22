using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform LeftCap;
    public Transform RightCap;


    public Vector3 LeftTarget;
    public Vector3 RightTarget;

    private Vector3 LeftStart;
    private Vector3 RightStart;
    private Vector3 LeftTween;
    private Vector3 RightTween;

    private Vector3 LeftOpen;
    private Vector3 RightOpen;
    private Vector3 LeftClosed;
    private Vector3 RightClosed;

    public float TargetWidth;
    private float WidthOpen;
    private float WidthClosed;

    public bool ScaleTween;
    public bool ScaleUp = false;
    private LineRenderer Line;

    public Color Grey;
    public Color White;
    public Color Alpha;
    public OptionsButton optionsButton;
    public float Speed;

    public bool Pressed;
    private int OpenSpeed = 10;
    private int CloseSpeed = 30;


    // Use this for initialization
    void Start ()
    {
        Line = GetComponent<LineRenderer>();
        LeftStart = LeftCap.localPosition;
        RightStart = RightCap.localPosition;
        LeftTween = new Vector3(LeftStart.x * .85f, LeftStart.y * .85f, LeftStart.z);
        RightTween = new Vector3(RightStart.x * .85f, RightStart.y * .85f, RightStart.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Line.SetPosition(0, LeftCap.position);
        Line.SetPosition(1, RightCap.position);

        if(optionsButton.xDelay)
        {
            LeftCap.localPosition = LeftStart;
            RightCap.localPosition = RightStart;
            Line.startWidth = 2.75f;
            Line.endWidth = 2.75f;
            ScaleTween = false;
            ScaleUp = false;
        }

        if (!optionsButton.Open)
        {
            Line.startColor = Color.Lerp(Line.startColor, Alpha, Time.deltaTime * CloseSpeed);
            Line.endColor = Color.Lerp(Line.endColor, Alpha, Time.deltaTime * CloseSpeed);
        }

        else if (!optionsButton.xDelay)
        {
            if (!Pressed)
            {
                Line.startColor = Color.Lerp(Line.startColor, White, Time.deltaTime * CloseSpeed);
                Line.endColor = Color.Lerp(Line.endColor, White, Time.deltaTime * CloseSpeed);
            }
            else
            {
                Line.startColor = Color.Lerp(Line.startColor, Grey, Time.deltaTime * OpenSpeed);
                Line.endColor = Color.Lerp(Line.endColor, Grey, Time.deltaTime * OpenSpeed);
            }
        }

        if (!ScaleUp)
        {
            if (ScaleTween)
            {
                WidthClosed = Mathf.Lerp(Line.widthMultiplier, 2.3375f, Time.deltaTime * Speed * 2);
                Line.widthMultiplier = WidthClosed;

                if (RightCap.localPosition.x > RightStart.x * .9f)
                {
                    LeftClosed = Vector3.Lerp(LeftCap.transform.localPosition, LeftTween, Time.deltaTime * Speed * 2);
                    RightClosed = Vector3.Lerp(RightCap.transform.localPosition, RightTween, Time.deltaTime * Speed * 2);
                    LeftCap.localPosition = LeftClosed;
                    RightCap.localPosition = RightClosed; 
                }
                else
                {
                    ScaleTween = false;
                }
            }
            else
            {
                WidthClosed = Mathf.Lerp(Line.widthMultiplier, 2.75f, Time.deltaTime * Speed);
                Line.widthMultiplier = WidthClosed;
                if (LeftCap.localPosition != LeftStart && RightCap.position != RightStart)
                {
                    LeftClosed = Vector3.Lerp(LeftCap.transform.localPosition, LeftStart, Time.deltaTime * Speed);
                    RightClosed = Vector3.Lerp(RightCap.transform.localPosition, RightStart, Time.deltaTime * Speed);
                    LeftCap.localPosition = LeftClosed;
                    RightCap.localPosition = RightClosed;
                }
            }
            Line.widthMultiplier = WidthClosed;
        }
        else if (ScaleUp)
        {
            ScaleTween = true;

            WidthOpen = Mathf.Lerp(Line.widthMultiplier, TargetWidth, Time.deltaTime * Speed );
            Line.widthMultiplier = WidthOpen;
            if (LeftCap.localPosition != LeftTarget && RightCap.localPosition != RightTarget)
            {
                LeftOpen = Vector3.Lerp(LeftCap.transform.localPosition, LeftTarget, Time.deltaTime * Speed);
                RightOpen = Vector3.Lerp(RightCap.transform.localPosition, RightTarget, Time.deltaTime * Speed);
                LeftCap.localPosition = LeftOpen;
                RightCap.localPosition = RightOpen;
            }
        }
	}

    void OpenSubmenu ()
    {

    }

    void CloseSubmenu ()
    {

    }
}
