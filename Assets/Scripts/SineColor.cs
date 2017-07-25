using UnityEngine;
using System.Collections;

public class SineColor : MonoBehaviour
{
    public CircleMask circleMask;
    public CustomizeButton customizeButton;
    public ColorChange colorChange;
    public Color StartColor;
    public Color TargetColor;
    private Color[] Rainbow;
    private Color[] Water;
    private Color[] Earth;
    private Color[] Fire;
    private Color[] Aether;
    private Color[] Light;
    private Color[] Dark;
    private Color[] Air;
    internal Color LerpColor;
    public int ColorIndex;
    public bool Started;
    public Color Black;
    public Color Alpha;
    public Color DarkAlpha;
    internal SpriteRenderer SpriteRend;
    public Color Grey;
    public bool Begin;

    // Use this for initialization
    void Start()
    {
        Rainbow = colorChange.Rainbow;
        Water = colorChange.Water;
        Earth = colorChange.Earth;
        Fire = colorChange.Fire;
        Aether = colorChange.Aether;
        Light = colorChange.Light;
        Dark = colorChange.Dark;
        Air = colorChange.Air;

        if (colorChange.IsRainbow)
        {
            TargetColor = Rainbow[ColorIndex];
        }
        else if (colorChange.IsFire)
        {
            TargetColor = Fire[ColorIndex];
        }
        else if (colorChange.IsAir)
        {
            TargetColor = Air[ColorIndex];
        }
        else if (colorChange.IsEarth)
        {
            TargetColor = Earth[ColorIndex];
        }
        else if (colorChange.IsWater)
        {
            TargetColor = Water[ColorIndex];
        }
        else if (colorChange.IsAether)
        {
            TargetColor = Aether[ColorIndex];
        }
        else if (colorChange.IsDark)
        {
            TargetColor = Dark[ColorIndex];
        }
        else if (colorChange.IsLight)
        {
            TargetColor = Light[ColorIndex];
        }
        TargetColor = colorChange.TargetColor;

        SpriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!circleMask.Open)
        {
            Started = false;
            StopCoroutine("StartSequence");
            
            if (!colorChange.IsDark)
            {
                SpriteRend.color = Alpha;
                LerpColor = Color.white;
            }
            else if (colorChange.IsDark)
            {
                SpriteRend.color = DarkAlpha;
                LerpColor = Grey;
            }
            return;
        }

        if (circleMask.Open)
        {
            if(!Started)
            {
                TargetColor = colorChange.TargetColor;
                StartCoroutine("StartSequence");
            }
            LerpColor = Color.Lerp(LerpColor, TargetColor, Time.deltaTime * 2);
            SpriteRend.color = LerpColor;

            if (colorChange.IsRainbow)
            {
                if (Rainbow.Length > ColorIndex)
                {
                    TargetColor = Rainbow[ColorIndex];
                }
                if (ColorIndex >= Rainbow.Length)
                {
                    ColorIndex = 0;
                }
            }

            if (colorChange.IsWater)
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

            if (colorChange.IsFire)
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

            if (colorChange.IsEarth)
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

            if (colorChange.IsLight)
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

            if (colorChange.IsDark)
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

            if (colorChange.IsAether)
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

            if (colorChange.IsAir)
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
        }
    }

    IEnumerator StartSequence()
    {
        Started = true;
        ColorIndex += 1;
        yield return new WaitForSeconds(1f);
        StartCoroutine("StartSequence");
    }
}
