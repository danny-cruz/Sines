using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitButton : MonoBehaviour
{

    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public OptionsButton optionsButton;
    public Text ButtonText;
    public Vector3 SubmenuScale;
    public DrawLine drawLine;

    public GameObject customizeButton;
    public GameObject gpgButton;

    public bool OpenSubmenu;
    public bool CustomizeOpen;
    public bool GPGOpen;


    private int OpenSpeed = 15;
    private int CloseSpeed = 30;
    private bool Pressed;

    private Vector3 StartPosition;
    private Vector3 TextOpen;
    private Vector3 TextClosed;
    private Vector3 CustomizeOpenPosition;
    private Vector3 CustomizeOpenTextPosition;

    private Vector3 GPGOpenPosition;
    private Vector3 GPGOpenTextPosition;

    private CustomizeButton customize;
#if !NO_GPGS
    private GPGButton gpg;
#else
    private ResetButton gpg;
#endif

    private Vector2 RectTargetScale;
    private Vector2 RectStartScale;
    private BoxCollider2D RectBox;

    // Use this for initialization
    void Start()
    {
        StartPosition = transform.localPosition;

        TextClosed = new Vector3(ButtonText.rectTransform.localPosition.x, ButtonText.rectTransform.localPosition.y, ButtonText.rectTransform.localPosition.z);
        TextOpen = new Vector3(ButtonText.rectTransform.localPosition.x, -90, ButtonText.rectTransform.localPosition.z);

        customize = customizeButton.GetComponent<CustomizeButton>();
        CustomizeOpenPosition = new Vector3(transform.localPosition.x, 0.1127f, transform.localPosition.z);
        CustomizeOpenTextPosition = new Vector3(transform.localPosition.x, -160, transform.localPosition.z);
#if !NO_GPGS
        GPGOpenPosition = new Vector3(transform.localPosition.x, 0.107f, transform.localPosition.z);
        GPGOpenTextPosition = new Vector3(transform.localPosition.x, -151, transform.localPosition.z);
        gpg = gpgButton.GetComponent<GPGButton>();
#else
        GPGOpenPosition = new Vector3(transform.localPosition.x, 0.107f, transform.localPosition.z);
        GPGOpenTextPosition = new Vector3(transform.localPosition.x, -151, transform.localPosition.z);
        gpg = gpgButton.GetComponent<ResetButton>();
#endif
        RectBox = GetComponent<BoxCollider2D>();
        RectTargetScale = new Vector2(10, 2.6f);
        RectStartScale = RectBox.size;

    }

    void Update()
    {

        if (!optionsButton.Open)
        {
            ButtonText.enabled = false;
            customize.ExitOpen = false;
            gpg.ExitOpen = false;
            drawLine.ScaleUp = false;
            transform.localPosition = StartPosition;
            ButtonText.rectTransform.localPosition = TextClosed;
            OpenSubmenu = false;
        }

        else if (!optionsButton.xDelay)
        {
            ButtonText.enabled = true;
            if (!Pressed)
            {
                if (OpenSubmenu)
                {
                    customize.ExitOpen = true;
                    gpg.ExitOpen = true;
                    customize.GPGOpen = false;
                    gpg.CustomizeOpen = false;
                    drawLine.ScaleUp = true;
                    RectBox.size = RectTargetScale;

                    ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, TextOpen, Time.deltaTime * OpenSpeed);
                    transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * OpenSpeed);

                    if ((customize.OpenSubmenu && CustomizeOpen) || (gpg.OpenSubmenu && GPGOpen))
                    {
                        customize.OpenSubmenu = false;
                        gpg.OpenSubmenu = false;
                        GPGOpen = false;
                        CustomizeOpen = false;
                    }

                }
                else if (!OpenSubmenu)
                {
                    drawLine.ScaleUp = false;
                    if (CustomizeOpen)
                    {
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, CustomizeOpenTextPosition, Time.deltaTime * OpenSpeed);
                        transform.localPosition = Vector3.Lerp(transform.localPosition, CustomizeOpenPosition, Time.deltaTime * OpenSpeed);
                    }
                    else if (GPGOpen)
                    {
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, GPGOpenTextPosition, Time.deltaTime * OpenSpeed);
                        transform.localPosition = Vector3.Lerp(transform.localPosition, GPGOpenPosition, Time.deltaTime * OpenSpeed);
                    }
                    else
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * CloseSpeed);
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, TextClosed, Time.deltaTime * CloseSpeed);
                        customize.ExitOpen = false;
                        gpg.ExitOpen = false;
                    }
                    RectBox.size = RectStartScale;
                }
            }
        }
    }

    void OnMouseOver()
    {

        if (Input.GetButtonDown("Touch"))
        {
            drawLine.Pressed = true;
            Pressed = true;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (Pressed)
            {
                drawLine.Pressed = false;
                Pressed = false;
                OpenSubmenu = !OpenSubmenu;
            }
        }
    }

    void OnMouseExit()
    {
        if (Pressed)
        {
            drawLine.Pressed = false;
            Pressed = false;
        }
    }

    void Reset()
    {
        
    }
}