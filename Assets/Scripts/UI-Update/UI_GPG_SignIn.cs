using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GooglePlayGames;
using TMPro;

public class UI_GPG_SignIn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public bool SignIn;
    public int StaySignedIn;

    public TextMeshProUGUI text;
    public LoadSave loadSave;
    private bool hasExited;

    void Start()
    {
        if(PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            SignIn = true;
            text.text = "Sign Out";
        }
        else if (PlayerPrefs.GetInt("LoggedIn") == 0)
        {
            SignIn = false;
            text.text = "Sign In";
        }
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
        if (!SignIn)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    SignIn = true;
                    PlayerPrefs.SetInt("LoggedIn", 1);
                    text.text = "Sign Out";
                }
                else
                {
                    Debug.Log("Failed");
                }
            });
        }
        if (SignIn)
        {
#if !NO_GPGS
            PlayGamesPlatform.Instance.SignOut();
#endif
            SignIn = false;
            PlayerPrefs.SetInt("LoggedIn", 0);
            text.text = "Sign In";
        }
        if (PlayerPrefs.GetInt("CloudSave") == 0)
        {
            loadSave.OpenSave(false);
        }
    }
}
