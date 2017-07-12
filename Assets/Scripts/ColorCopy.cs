using UnityEngine;
using System.Collections;

public class ColorCopy : MonoBehaviour {
	private SpriteRenderer SpriteRend;
	private ColorChange ColorC;
	public GameObject Parent;
	public Color LerpColor2;


	// Use this for initialization
	void Start () {
		SpriteRend = GetComponent<SpriteRenderer>();
		ColorC = Parent.GetComponent<ColorChange>();

	}
	
	// Update is called once per frame
	void Update () {
		LerpColor2 = ColorC.LerpColor;

		SpriteRend.color = LerpColor2;
		


	}
}
