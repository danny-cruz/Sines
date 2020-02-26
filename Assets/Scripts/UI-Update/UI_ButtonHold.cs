using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UI_ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public Color ImageColorDefault;
    public Color ImageColorHold;

    public Color TextColorDefault;
    public Color TextColorHold;

    private Color targetImageColor;
    private Color targetTextColor;

    private Vector3 imageScaleDefault;
    private Vector3 textScaleDefault;

    private bool hasExited;
    public Image myImage;
    public TextMeshProUGUI myText;

    public float Speed;
    void Start()
    {
        targetImageColor = ImageColorDefault;
        targetTextColor = TextColorDefault;

        imageScaleDefault = myImage.transform.localScale;
        textScaleDefault = myText.transform.localScale;

        //ImageColorHold = ImageColorDefault * (Color.white * Color.grey);
        //TextColorHold = TextColorDefault * (Color.white * Color.grey);
    }

    void Update()
    {
        if(myImage.color != targetImageColor)
        {
            myImage.color = Color.Lerp(myImage.color, targetImageColor, Time.deltaTime * Speed);
        }
        if (myText.color != targetTextColor)
        {
            myText.color = Color.Lerp(myText.color, targetTextColor, Time.deltaTime * Speed);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        targetImageColor = ImageColorHold;
        targetTextColor = TextColorHold;
        myImage.transform.localScale = imageScaleDefault * .98f;
        //myText.transform.localScale = textScaleDefault * .98f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetImageColor = ImageColorDefault;
        targetTextColor = TextColorDefault;
        myImage.transform.localScale = imageScaleDefault;
        myText.transform.localScale = textScaleDefault;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        targetImageColor = ImageColorDefault;
        targetTextColor = TextColorDefault;
        myImage.transform.localScale = imageScaleDefault;
        myText.transform.localScale = textScaleDefault;
    }
} 
