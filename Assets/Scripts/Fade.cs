using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	public Color Black;
    public Color Gray;
	public Color Alpha;
	public float Speed;
	private SpriteRenderer SpriteRend;
	public float DelayCount;
	public bool FadeAlpha;
	public bool FadeBlack;
    public GameOverText GameOver;
    public ResetButton resetButton;
    public GameObject TapToContinue;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Delay");
		SpriteRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameOver.Fade)
        {
            TapToContinue.SetActive(true);
            FadeAlpha = false;
            SpriteRend.color = Color.Lerp(SpriteRend.color, Black, Time.deltaTime * Speed *.75f);
        }
        if (FadeAlpha)
        {
	        SpriteRend.color = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * 5);
	    }

	    
	}
    private IEnumerator Delay ()
    {
        yield return new WaitForSeconds(DelayCount);
        FadeAlpha = true;
    }
}
