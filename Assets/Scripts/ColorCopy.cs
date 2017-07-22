using UnityEngine;
using System.Collections;

public class ColorCopy : MonoBehaviour {
	private SpriteRenderer SpriteRend;
	private ColorChange ColorC;
	public GameObject Parent;
	public Color LerpColor;
    public Color Alpha;
    public bool Radial;

	// Use this for initialization
	void Start () {
		SpriteRend = GetComponent<SpriteRenderer>();
		ColorC = Parent.GetComponent<ColorChange>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((ColorC.IsDark || ColorC.IsLight) && Radial)
        {
            if(!OptionsButton.Pause)
            LerpColor = Color.Lerp(LerpColor, Alpha, Time.deltaTime * 7);
        }
        else
        {
            LerpColor = ColorC.LerpColor;
        }

        SpriteRend.color = LerpColor;

    }
}
