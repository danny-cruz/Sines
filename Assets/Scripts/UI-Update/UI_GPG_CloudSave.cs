using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.EventSystems;
using TMPro;

public class UI_GPG_CloudSave : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public LoadSave loadSave;
    public TextMeshProUGUI cloudSaveText;
    private bool hasExited;
    private string cloudSaveOn = "Cloud Save: On";
    private string cloudSaveOff = "Cloud Save: Off";

    void Start()
    {
        if (PlayerPrefs.GetInt("CloudSave") == 0)     //enabled by default
        {
            cloudSaveText.text = cloudSaveOn;
        }
        else if (PlayerPrefs.GetInt("CloudSave") == 1)
        {
            cloudSaveText.text = cloudSaveOff;
        }
    }

    void Update () 
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
        if (PlayerPrefs.GetInt("CloudSave") == 0)
        {
            PlayerPrefs.SetInt("CloudSave", 1);
            cloudSaveText.text = cloudSaveOff;
        }
       else if (PlayerPrefs.GetInt("CloudSave") == 1)
        {
            PlayerPrefs.SetInt("CloudSave", 0);
            cloudSaveText.text = cloudSaveOn;
            loadSave.OpenSave(true);
        }
    }
}
