using UnityEngine;
using System.Collections;

public class ColorCopy : MonoBehaviour {
	private SpriteRenderer SpriteRend;
	private ColorChange ColorC;
	public GameObject Parent;
	public Color LerpColor;
    public Color Alpha;
    public bool Radial;
    public bool StartSprite;

    // Use this for initialization
    void Start()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
        ColorC = Parent.GetComponent<ColorChange>();
        if ((ColorC.IsDark || ColorC.IsLight) && Radial)
        {
            if (!StartSprite)
            {
                SpriteRend.color = Alpha;
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (!UI_OptionsButton.Pause)
        {
            if ((ColorC.IsDark || ColorC.IsLight) && Radial)
            {
                if (!StartSprite)
                {
                    LerpColor = Color.Lerp(LerpColor, Alpha, Time.deltaTime * 10);
                }
            }
            else
            {
                if (!StartSprite)
                {
                    if (!Radial && ColorC.Begin)
                    {
                        LerpColor = Alpha;
                    }
                    else
                    {
                        LerpColor = ColorC.LerpColor;
                    }
                }
                else if (ColorC.Begin)
                {
                    LerpColor = Color.Lerp(ColorC.LerpColor, ColorC.TargetColor, Time.deltaTime * 4);
                }
            }
        }

        SpriteRend.color = LerpColor;

    }
}
