using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PrivacyPolicyReturnButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public bool EnableLogo;
    public GameObject Logo;
    public GameObject CurrentCanvas;
    public GameObject TargetCanvas;
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
            if(EnableLogo)
            {
                Logo.SetActive(true);
            }
            else
            {
                Logo.SetActive(false);
            }
            TargetCanvas.SetActive(true);
            CurrentCanvas.SetActive(false);
        }
    }
}