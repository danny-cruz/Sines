using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrivacyPolicyAccept : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public PrivacyPolicyLogo privacyPolicyLogo;
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
            privacyPolicyLogo.StartCoroutine("DelayedFade");
            privacyPolicyLogo.unlocked = true;
        }
    }
}