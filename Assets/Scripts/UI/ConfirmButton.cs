using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;


public class ConfirmButton : MonoBehaviour
{
    public Color Grey;
    public Color Alpha;
    public Color ButtonDownColor;
    public ExitButton exitButton;
    public Text ButtonText;
    private Color LerpColor;
    private bool Pressed;
    private SpriteRenderer SpriteRend;

    private Vector3 StartScale;
    private Vector3 TargetScale;
    private Vector3 CustomizeTextPosition;
    private Vector3 GPGTextPosition;
    private Vector3 StartTextPosition;

    private BoxCollider2D Rect;
    private bool CheckText;
    // Use this for initialization
    void Awake()
    {
        StartScale = transform.localScale;
        TargetScale = new Vector3(transform.localScale.x * .9f, transform.localScale.y * .9f, transform.localScale.z);
        CustomizeTextPosition = new Vector3(ButtonText.rectTransform.localPosition.x, -134, ButtonText.rectTransform.localPosition.z);
        GPGTextPosition = new Vector3(ButtonText.rectTransform.localPosition.x, -125, ButtonText.rectTransform.localPosition.z);
        StartTextPosition = ButtonText.rectTransform.localPosition;
        SpriteRend = GetComponent<SpriteRenderer>();
        Rect = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(exitButton.OpenSubmenu)
        {
            if (!Pressed)
            {
                LerpColor = Color.Lerp(SpriteRend.color, Grey, Time.deltaTime * 5);
                SpriteRend.color = LerpColor;
                ButtonText.enabled = true;
                transform.localScale = Vector3.Lerp(transform.localScale, StartScale, Time.deltaTime * 15);
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Time.deltaTime * 15);
            }

            if (!CheckText)
            {
                if (exitButton.GPGOpen)
                {
                    ButtonText.rectTransform.localPosition = GPGTextPosition;
                }
                else if (exitButton.CustomizeOpen)
                {
                    ButtonText.rectTransform.localPosition = CustomizeTextPosition;
                }
                else
                {
                    ButtonText.rectTransform.localPosition = StartTextPosition;
                }
                CheckText = true;
            }
            else
            {
                ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, StartTextPosition, Time.deltaTime * 15);
            }
            Rect.enabled = true;
        }
        else
        {
            ButtonText.enabled = false;
            CheckText = false;
            SpriteRend.color = Alpha;
            if (exitButton.GPGOpen)
            {
                ButtonText.rectTransform.localPosition = GPGTextPosition;
            }
            else if (exitButton.CustomizeOpen)
            {
                ButtonText.rectTransform.localPosition = CustomizeTextPosition;
            }
            else
            {
                ButtonText.rectTransform.localPosition = StartTextPosition;
            }
            Rect.enabled = false;

         
        }
    }

    void OnMouseOver()
    {

        if (Input.GetButtonDown("Touch"))
        {
            Pressed = true;
            SpriteRend.color = ButtonDownColor;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (Pressed)
            {
                Pressed = false;
                Application.Quit();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }

    void OnMouseExit()
    {
        Pressed = false;
    }
}
