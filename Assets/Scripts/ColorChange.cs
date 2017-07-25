using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour
{

	public Color StartColor;
	public Color TargetColor;
    public bool IsRainbow, IsFire, IsAir, IsEarth, IsWater, IsAether, IsLight, IsDark; 
	public Color[] Rainbow;
    public Color[] Water;
    public Color[] Earth;
    public Color[] Fire;
    public Color[] Aether;
    public Color[] Light;
    public Color[] Dark;
    public Color[] Air;
    internal Color LerpColor;
	private TrailRenderer TrailRend;
	public int ColorIndex;
	private bool Started;
	public Player PlayerPoint;
	private Color LerpBlack;
	internal bool Close;
	public Color Alpha;
	internal bool Lost;
	private Controller controller;
	public GameObject ControllerObject;

    public bool Begin;
    public bool Left;
	// Use this for initialization
	void Start ()
    {
        if (Left)
        {
            if (PlayerPrefs.GetInt("LeftColor") == 0)
            {
                IsRainbow = true;
                TargetColor = Rainbow[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 1)
            {
                IsFire = true;
                TargetColor = Fire[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 2)
            {
                IsAir = true;
                TargetColor = Air[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 3)
            {
                IsEarth = true;
                TargetColor = Earth[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 4)
            {
                IsWater = true;
                TargetColor = Water[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 5)
            {
                IsAether = true;
                TargetColor = Aether[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 6)
            {
                IsDark = true;
                TargetColor = Dark[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("LeftColor") == 7)
            {
                IsLight = true;
                TargetColor = Light[ColorIndex];
            }
        }
        else if (!Left)
        {
            if (PlayerPrefs.GetInt("RightColor") == 0)
            {
                IsRainbow = true;
                TargetColor = Rainbow[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 1)
            {
                IsFire = true;
                TargetColor = Fire[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 2)
            {
                IsAir = true;
                TargetColor = Air[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 3)
            {
                IsEarth = true;
                TargetColor = Earth[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 4)
            {
                IsWater = true;
                TargetColor = Water[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 5)
            {
                IsAether = true;
                TargetColor = Aether[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 6)
            {
                IsDark = true;
                TargetColor = Dark[ColorIndex];
            }
            else if (PlayerPrefs.GetInt("RightColor") == 7)
            {
                IsLight = true;
                TargetColor = Light[ColorIndex];
            }
        }
        controller = ControllerObject.GetComponent<Controller>();
		TrailRend = GetComponent<TrailRenderer>();
		LerpColor = StartColor;
	}

    // Update is called once per frame
    void Update()
    {
        if (OptionsButton.Pause)
        {
            StopCoroutine("StartSequence");
            return;
        }

        Begin = controller.Begin;
        Lost = PlayerPoint.Lost;
        TrailRend.material.SetColor("_Color", LerpColor);

        if (Lost)
        {
            StopCoroutine("StartSequence");
            StartCoroutine("GO");
            LerpColor = Color.Lerp(LerpColor, Alpha, Time.deltaTime * 5);
        }

        if (!Lost && Begin)
        {
            LerpColor = Color.Lerp(LerpColor, TargetColor, Time.deltaTime * 4);
            LerpBlack = LerpColor;
            TrailRend.material.SetColor("_Color", LerpColor);

            if (IsRainbow)
            {
                if(Rainbow.Length > ColorIndex)
                {
                    TargetColor = Rainbow[ColorIndex];
                }
                if (ColorIndex >= Rainbow.Length)
                {
                    ColorIndex = 0; 
                }
            }

            if (IsWater)
            {
                if (Water.Length > ColorIndex)
                {
                    TargetColor = Water[ColorIndex];
                }
                if (ColorIndex >= Water.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (IsFire)
            {
                if (Fire.Length > ColorIndex)
                {
                    TargetColor = Fire[ColorIndex];
                }
                if (ColorIndex >= Fire.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (IsEarth)
            {
                if (Earth.Length > ColorIndex)
                {
                    TargetColor = Earth[ColorIndex];
                }
                if (ColorIndex >= Earth.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (IsLight)
            {
                if (Light.Length > ColorIndex)
                {
                    TargetColor = Light[ColorIndex];
                }
                if (ColorIndex >= Light.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (IsDark)
            {
                if (Dark.Length > ColorIndex)
                {
                    TargetColor = Dark[ColorIndex];
                }
                if (ColorIndex >= Dark.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (IsAether)
            {
                if (Aether.Length > ColorIndex)
                {
                    TargetColor = Aether[ColorIndex];
                }
                if (ColorIndex >= Aether.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (IsAir)
            {
                if (Air.Length > ColorIndex)
                {
                    TargetColor = Air[ColorIndex];
                }
                if (ColorIndex >= Air.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (transform.position.x > -.3f && transform.position.x < .3f)
            {

                if (!Started)
                {
                    StartCoroutine("StartSequence");
                }
            }

            if (transform.position.x < -1.3f || transform.position.x > 1.3f)
            {
                //LerpColor = Color.Lerp(LerpColor, StartColor, Time.deltaTime * .2f);
                Started = false;
                StopCoroutine("StartSequence");
            }
        }
    }

	IEnumerator StartSequence ()
    {
		Started = true;
		ColorIndex +=1;
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("StartSequence");
	}

    IEnumerator GO()
    {
        yield return new WaitForSeconds(1.5f);
        Close = true;
    }
}
