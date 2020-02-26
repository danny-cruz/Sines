using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PrivacyPolicyArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public PrivacyPolicyPageNumber PageNumber;
    public bool LeftArrow;
    private bool hasExited;
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        hasExited = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasExited = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (hasExited)
        {
            hasExited = false;
            return;
        }
        else
        {
            if(LeftArrow)
            {
                PageNumber.PageNumber--;
            }
            else if (!LeftArrow)
            {
                PageNumber.PageNumber++;
            }
        }
    }
}