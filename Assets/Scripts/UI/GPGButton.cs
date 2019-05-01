using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GPGButton : MonoBehaviour
{

    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public UI_OptionsButton optionsButton;
    public Text ButtonText;
    public DrawLine drawLine;
    private Vector3 StartScale;
    private Vector3 StartPosition;
    private Vector3 TargetScale;
    private Color AlphaLerp;
    private Color WhiteLerp;
    public GameObject GPG_Achievements;
    public GameObject GPG_Leaderboards;
    public GameObject GPG_SignIn;
    public GameObject GPG_Rate;

    private Vector3 TextOpen;
    private Vector3 TextClosed;

    private bool Pressed;

    public bool OpenSubmenu;

    public GameObject customizeButton;
    public GameObject exitButton;

    private CustomizeButton customize;
    private ExitButton exit;

    public bool CustomizeOpen;

    private int OpenSpeed = 15;
    private int CloseSpeed = 30;

    private Vector3 CustomizeOpenPosition;
    private Vector3 CustomizeOpenTextPosition;
    private Vector3 ExitOpenPosition;
    private Vector3 ExitOpenTextPosition;

    public bool ExitOpen;

    private Vector2 RectTargetScale;
    private Vector2 RectStartScale;
    private BoxCollider2D RectBox;

    // Use this for initialization
    void Start()
    {
        StartScale = transform.localScale;
        TargetScale = StartScale;
        TextClosed = new Vector3(ButtonText.rectTransform.localPosition.x, ButtonText.rectTransform.localPosition.y, ButtonText.rectTransform.localPosition.z);
        TextOpen = new Vector3(ButtonText.rectTransform.localPosition.x, -32, ButtonText.rectTransform.localPosition.z);

        CustomizeOpenPosition = new Vector3(transform.localPosition.x, 0.0877f, transform.localPosition.z);
        CustomizeOpenTextPosition = new Vector3(transform.localPosition.x, -122, transform.localPosition.z);

        ExitOpenPosition = new Vector3(transform.localPosition.x, 0.043f, transform.localPosition.z);
        ExitOpenTextPosition = new Vector3(transform.localPosition.x, -53.3f, transform.localPosition.z);

        StartPosition = transform.localPosition;
        customize = customizeButton.GetComponent<CustomizeButton>();
        exit = exitButton.GetComponent<ExitButton>();

        RectBox = GetComponent<BoxCollider2D>();
        RectTargetScale = new Vector2(10, 4.4f);
        RectStartScale = RectBox.size;
    }

    void Update()
    {

        if (!optionsButton.Open)
        {
            ButtonText.enabled = false;
            customize.GPGOpen = false;
            exit.GPGOpen = false;
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
                    drawLine.ScaleUp = true;
                    customize.GPGOpen = true;
                    exit.GPGOpen = true;
                    customize.ExitOpen = false;
                    exit.CustomizeOpen = false;
                    GPG_Achievements.SetActive(true);
                    GPG_Leaderboards.SetActive(true);
                    GPG_SignIn.SetActive(true);
                    GPG_Rate.SetActive(true);


                    ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, TextOpen, Time.deltaTime * OpenSpeed);           
                    transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * OpenSpeed);

                    RectBox.size = RectTargetScale;
                    if((customize.OpenSubmenu && CustomizeOpen) || (exit.OpenSubmenu && ExitOpen))
                    {
                        customize.OpenSubmenu = false;
                        exit.OpenSubmenu = false;
                        ExitOpen = false;
                        CustomizeOpen = false;
                    }
                }
                else if (!OpenSubmenu)
                {
                    if (CustomizeOpen)
                    {
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, CustomizeOpenTextPosition, Time.deltaTime * OpenSpeed);
                        drawLine.ScaleUp = false;
                        if (ButtonText.rectTransform.localPosition.y < -70)
                        {
                            transform.localPosition = Vector3.Lerp(transform.localPosition, CustomizeOpenPosition, Time.deltaTime * OpenSpeed);      
                        }
                    }
                    else if (ExitOpen)
                    {
                        if (transform.localPosition.y < 0.05f)
                        {
                            drawLine.ScaleUp = false;
                            
                        }
                        transform.localPosition = Vector3.Lerp(transform.localPosition, ExitOpenPosition, Time.deltaTime * OpenSpeed);
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, ExitOpenTextPosition, Time.deltaTime * OpenSpeed);
                        
                    }
                    else
                    {
                        drawLine.ScaleUp = false;
                        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * CloseSpeed);    
                        ButtonText.rectTransform.localPosition = Vector3.Lerp(ButtonText.rectTransform.localPosition, TextClosed, Time.deltaTime * CloseSpeed);
                        customize.GPGOpen = false;
                        exit.GPGOpen = false;
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
            Pressed = false;
            drawLine.Pressed = false;
        }
    }
}