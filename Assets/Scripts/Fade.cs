using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	public bool Title;
	public Color Black;
	public Color Alpha;
	public float Speed;
	private SpriteRenderer SpriteRend;
	public float DelayCount;
	public bool FadeAlpha;
	public bool FadeBlack;
	// Use this for initialization
	void Start () {
		if(Title){
		StartCoroutine("Delay");
		}
		SpriteRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	if(FadeAlpha){
	SpriteRend.color = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * Speed);
	}

	if(FadeBlack){
		
			SpriteRend.color = Color.Lerp(SpriteRend.color, Black, Time.deltaTime * Speed );
		}

	}

	IEnumerator Delay (){
	
		FadeAlpha = true;
		yield return new WaitForSeconds(DelayCount);
		FadeAlpha = false;
		FadeBlack = true;

	}
}
