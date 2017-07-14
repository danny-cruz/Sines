using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GPG_Rate : MonoBehaviour
{
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    private SpriteRenderer SpriteRend;
	private bool SignedIn;
	private bool Pressed;
	// Use this for initialization
	void Start ()
    {
		SpriteRend = GetComponent<SpriteRenderer>();
	}
	
	void OnMouseOver()
    {
	
		if(Input.GetButtonDown("Touch"))
        {
			SpriteRend.color = ButtonDownColor;
			Pressed = true;
		}

		if(Input.GetButtonUp("Touch"))
        {
			if (Pressed)
            {
				Application.OpenURL ("market://details?id=io.danielcruz.sines");			
				Pressed = false;
                SpriteRend.color = ButtonUpColor;
            }
		}
	}

	void OnMouseExit ()
    {
        if (Pressed)
        {
            Pressed = false;
            SpriteRend.color = ButtonUpColor;
        }
    }


}
