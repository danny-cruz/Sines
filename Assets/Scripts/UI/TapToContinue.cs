using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapToContinue : MonoBehaviour {

    public float Speed;
    private TextMeshProUGUI text;
    private bool Delayed = false;
    public Color TargetColor;
    private Color Alpha;
    public UI_OptionsButton optionsButton;

    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();
        Alpha = text.color;
        StartCoroutine("Delay");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(optionsButton.Open)
        {
            text.color = Color.Lerp(text.color, Alpha, Time.deltaTime * 15);
        }
        else if (text.color != TargetColor && Delayed && optionsButton.xDelay)
        {
            text.color = Color.Lerp(text.color, TargetColor, Time.deltaTime * Speed);
        }

	}
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);
        Delayed = true;
    }
}
