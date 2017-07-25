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
	void Start () {
		SpriteRend = GetComponent<SpriteRenderer>();
		ColorC = Parent.GetComponent<ColorChange>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!OptionsButton.Pause)
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
                    LerpColor = ColorC.LerpColor;
                }
                else if (ColorC.Begin)
                {
                    LerpColor = ColorC.LerpColor;
                }
            }
        }

        SpriteRend.color = LerpColor;

    }
}
