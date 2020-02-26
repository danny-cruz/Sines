using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;

public class UI_GPG_Achievements : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private bool hasExited;

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
        Social.ShowAchievementsUI();
    }
}
