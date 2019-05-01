using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ExitButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public CanvasGroup ExitButtonGroup;
    public CanvasGroup ExitSubmenu;
    public CanvasGroup ArrowGroup;
    public Animator a_ExitImage, a_ExitImage2, a_ExitText;
    public Animator a_BackArrow;
    public Image i_ExitImage2;

    public float alphaFade;
    public bool Open;

    private float submenuTargetAlpha;
    private float arrowTargetAlpha;
    public CanvasGroup myGroup;
    private bool hasExited;
	void Start () 
	{

	}
	
	void Update () 
	{
        if(ExitSubmenu.alpha != submenuTargetAlpha)
        {
            ExitSubmenu.alpha = Mathf.Lerp(ExitSubmenu.alpha, submenuTargetAlpha, Time.deltaTime * alphaFade);
        }
        if (ArrowGroup.alpha != arrowTargetAlpha)
        {
            ArrowGroup.alpha = Mathf.Lerp(ArrowGroup.alpha, arrowTargetAlpha, Time.deltaTime * alphaFade);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        hasExited = false;
        if (!Open)
        {
            a_ExitImage.SetBool("hold", true);
            a_ExitImage2.SetBool("hold", true);
            a_ExitText.SetBool("hold", true);
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        hasExited = true;
        if (!Open)
        {
            a_ExitImage.SetBool("hold", false);
            a_ExitImage2.SetBool("hold", false);
            a_ExitText.SetBool("hold", false);
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (hasExited)
        {
            hasExited = false;
            return;
        }

        a_ExitImage.SetBool("hold", false);
        a_ExitImage2.SetBool("hold", false);
        a_ExitText.SetBool("hold", false);
        

        if (!Open)
        {
            StopAllCoroutines();
            StartCoroutine("OpenSubmenu");
            Open = true;

        }


        



        /*
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
        */

       
    }


    IEnumerator OpenSubmenu()
    {
        alphaFade = 10;
        ExitButtonGroup.alpha = 1;
        
        i_ExitImage2.color = Color.clear;
        ArrowGroup.gameObject.SetActive(true);
        a_ExitImage.SetBool("isOpen", true);
        a_ExitImage2.SetBool("isOpen", true);
        a_ExitText.SetBool("isOpen", true);
        
        yield return new WaitForSeconds(.1f);
        submenuTargetAlpha = 1;
        arrowTargetAlpha = 1;
        a_BackArrow.ResetTrigger("close");
        a_BackArrow.SetTrigger("open");
        yield return new WaitForSeconds(.125f);
        
        ExitSubmenu.gameObject.SetActive(true);
        
        


    }
    IEnumerator CloseSubmenu()
    {
        alphaFade = 20;
        Open = false;
        a_ExitImage.SetBool("isOpen", false);
        a_ExitImage2.SetBool("isOpen", false);
        a_ExitText.SetBool("isOpen", false);
        a_BackArrow.ResetTrigger("open");
        a_BackArrow.SetTrigger("close");
        submenuTargetAlpha = 0;
        yield return new WaitForSeconds(.15f);
        arrowTargetAlpha = 0;
        yield return new WaitForSeconds(.15f);
        ArrowGroup.gameObject.SetActive(false);
        ExitSubmenu.gameObject.SetActive(false);
        i_ExitImage2.color = Color.white;
        ExitButtonGroup.alpha = 0;
       

    }
}
