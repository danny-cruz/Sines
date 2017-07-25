using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMask : MonoBehaviour
{

    public bool Open;
    public bool Gradient;
    public Color Black;
    public Color Alpha;

    public CustomizeButton customizeButton;

    private bool Started;
    private SpriteRenderer SpriteRend;
    private Color LerpColor;

    // Use this for initialization
    void Start ()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!customizeButton.OpenSubmenu)
        {
            Open = false;
            SpriteRend.color = Alpha;
            Started = false;
            StopCoroutine("FadeIn");
            return;
        }
        if (customizeButton.OpenSubmenu)
        {
            if (!Started)
            {
                StartCoroutine("FadeIn");
            }
            if (!Gradient)
            {
                LerpColor = Color.Lerp(SpriteRend.color, Black, Time.deltaTime * 4);
                SpriteRend.color = LerpColor;
            }
            else if(Gradient && Open)
            {
                LerpColor = Color.Lerp(SpriteRend.color, Black, Time.deltaTime * 2);
                SpriteRend.color = LerpColor;
            }
        }
    }

    IEnumerator FadeIn()
    {
        Started = true;
        yield return new WaitForSeconds(.15f);
        Open = true;
    }
}
