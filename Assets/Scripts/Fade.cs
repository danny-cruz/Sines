using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
	public Color Black;
    public Color Gray;
	public Color Alpha;
	public float Speed;
	private Image image;
	public float DelayCount;
	public bool FadeAlpha;
	public bool FadeBlack;
    public GameObject TapToContinue;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Delay");
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (FadeBlack)
        {
            TapToContinue.SetActive(true);
            FadeAlpha = false;
            image.color = Color.Lerp(image.color, Black, Time.deltaTime * Speed *.75f);
        }
        if (FadeAlpha)
        {
            FadeBlack = false;
            image.color = Color.Lerp(image.color, Alpha, Time.deltaTime * 3);
	    }    
	}

    private IEnumerator Delay ()
    {
        yield return new WaitForSeconds(DelayCount);
        FadeAlpha = true;
    }
}
