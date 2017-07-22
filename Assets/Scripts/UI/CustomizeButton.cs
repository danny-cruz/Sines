using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CustomizeButton : MonoBehaviour
{

    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public OptionsButton optionsButton;
    public Text ButtonText;
    public Vector3 SubmenuScale;
    public DrawLine drawLine;
    private Vector3 StartScale;
    private Vector3 TargetScale;
    private Color AlphaLerp;
    private Color WhiteLerp;

    private Vector3 TextOpen;
    private Vector3 TextClosed;

    private int OpenSpeed = 10;
    private int CloseSpeed = 30;
    private bool Pressed;
    


    private Vector3 StartPosition;

    private Vector3 GPGOpenTextPosition;
    private Vector3 GPGOpenPosition;

    private Vector3 ExitOpenTextPosition;
    private Vector3 ExitOpenPosition;

    public bool OpenSubmenu;
    public bool GPGOpen;
    public bool ExitOpen;

    public GameObject gpgButton;
    public GameObject exitButton;

    private GPGButton gpg;
    private ExitButton exit;

    
    // Use this for initialization
    void Start()
    {
        StartPosition = transform.localPosition;
        StartScale = transform.localScale;
        TargetScale = StartScale;
        drawLine.TargetWidth = 12;
        TextClosed = new Vector3(ButtonText.rectTransform.localPosition.x, ButtonText.rectTransform.localPosition.y, ButtonText.rectTransform.localPosition.z);
        TextOpen = new Vector3(ButtonText.rectTransform.localPosition.x, 17, ButtonText.rectTransform.localPosition.z);

        GPGOpenTextPosition = new Vector3(ButtonText.rectTransform.localPosition.x, 6.7f, ButtonText.rectTransform.localPosition.z);
        GPGOpenPosition = new Vector3(transform.localPosition.x, 0.0036f, transform.localPosition.z);

        ExitOpenTextPosition = new Vector3(ButtonText.rectTransform.localPosition.x, -15, ButtonText.rectTransform.localPosition.z);
        ExitOpenPosition = new Vector3(transform.localPosition.x, 0.0179f, transform.localPosition.z);
        gpg = gpgButton.GetComponent<GPGButton>();
        exit = exitButton.GetComponent<ExitButton>();
    }

    void Update()
    {

        if (!optionsButton.Open)
        {  
            ButtonText.enabled = false;
            gpg.CustomizeOpen = false;
            exit.CustomizeOpen = false;
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
                    gpg.CustomizeOpen = true;
                    exit.CustomizeOpen = true;
                    gpg.ExitOpen = false;
                    exit.GPGOpen = false;

                    drawLine.ScaleUp = true;
                    transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * 15);
                    ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, TextOpen, Time.deltaTime * 15);

                    if ((gpg.OpenSubmenu && GPGOpen) || (exit.OpenSubmenu && ExitOpen))
                    {
                        gpg.OpenSubmenu = false;
                        exit.OpenSubmenu = false;
                        ExitOpen = false;
                        GPGOpen = false;
                    }
                }
                else if (!OpenSubmenu)
                {
                    if (GPGOpen)
                    {
                        if (transform.localPosition.y < 0.017)
                        {
                            drawLine.ScaleUp = false;
                        }
                        transform.localPosition = Vector3.Lerp(transform.localPosition, GPGOpenPosition, Time.deltaTime * 15);
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, GPGOpenTextPosition, Time.deltaTime * 15);
                    }
                    else if (ExitOpen)
                    {
                        if (ButtonText.rectTransform.localPosition.y < 0)
                        {
                            drawLine.ScaleUp = false;
                        }
                        transform.localPosition = Vector3.Lerp(transform.localPosition, ExitOpenPosition, Time.deltaTime * 15);
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, ExitOpenTextPosition, Time.deltaTime * 15);
                    }
                    else
                    {
                        drawLine.ScaleUp = false;
                        
                        gpg.CustomizeOpen = false;
                        exit.CustomizeOpen = false;
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, TextClosed, Time.deltaTime * 30);
                        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * 30);
                    }
                    
                }
            }
        }
    }
    void OnMouseOver()
    {

        if (Input.GetButtonDown("Touch"))
        {
            Pressed = true;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (Pressed)
            {
                Pressed = false;
                OpenSubmenu = !OpenSubmenu;
                //Application.Quit();
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }

    void OnMouseExit()
    {
        if (Pressed)
        {
            Pressed = false;
            //SpriteRend.color = ButtonUpColor;
        }
    }

    private void Reset()
    {
        
    }
}