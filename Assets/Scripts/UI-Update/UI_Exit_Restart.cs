using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Exit_Restart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public Fade Fader;
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
        if(hasExited)
        {
            hasExited = false;
            return;
        }
        Fader.FadeBlack = true;
        StartCoroutine("Restart");
        
    }

    IEnumerator Restart ()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Android", LoadSceneMode.Single);
    }
}
