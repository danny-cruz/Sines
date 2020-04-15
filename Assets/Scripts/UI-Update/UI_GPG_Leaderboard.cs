using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UI_GPG_Leaderboard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
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
#if !NO_GPGS
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIlu2Nm5MWEAIQCQ");
#endif
    }
}
