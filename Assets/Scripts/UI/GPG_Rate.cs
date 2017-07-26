using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GPG_Rate : MonoBehaviour
{
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public OptionsButton optionsButton;
    public Text text;
    public SpriteRenderer IconSpriteRend;

    private Color AlphaLerp;
    private Color WhiteLerp;
    private SpriteRenderer SpriteRend;
    public GPGButton gpgButton;

    private int OpenSpeed = 5;
    private int CloseSpeed = 30;
	private bool Pressed;

    private Vector3 StartScale;
    private Vector3 TargetScale;
    // Use this for initialization
    void Awake ()
    {
		SpriteRend = GetComponent<SpriteRenderer>();
        StartScale = transform.localScale;
        TargetScale = new Vector3(transform.localScale.x * .95f, transform.localScale.y * .95f, transform.localScale.z);
    }

    private void Update()
    {

        if (!gpgButton.OpenSubmenu)
        {
            AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);

            SpriteRend.color = Alpha;
            text.color = Alpha;
            text.enabled = false;
            IconSpriteRend.color = Alpha;
            this.gameObject.SetActive(false);
        }

        else if (!optionsButton.xDelay && gpgButton.OpenSubmenu)
        {
            if (!Pressed)
            {
                WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);
                transform.localScale = Vector3.Lerp(transform.localScale, StartScale, Time.deltaTime * 15);
                SpriteRend.color = WhiteLerp;
                text.enabled = true;
                text.color = Color.white;
                IconSpriteRend.color = Color.white;
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Time.deltaTime * 15);
            }
        }
    }
    void OnMouseOver()
    {
        if (!gpgButton.OpenSubmenu)
        {
            return;
        }

        if (Input.GetButtonDown("Touch"))
        {	
			Pressed = true;
            SpriteRend.color = ButtonDownColor;
        }

		if(Input.GetButtonUp("Touch"))
        {
			if (Pressed)
            {
                #if !NO_GPGS
                Application.OpenURL ("market://details?id=io.danielcruz.sines");	
#endif
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
            //SpriteRend.color = ButtonUpColor;
        }
    }


}
