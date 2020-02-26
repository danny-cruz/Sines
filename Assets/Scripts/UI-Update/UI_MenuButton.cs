using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public ReturnToPrivacyPolicyButton LogoButton;
    public CanvasGroup ButtonGroup;
    public CanvasGroup SubmenuGroup;
    public CanvasGroup ArrowGroup;
    public Animator a_ButtonImage, a_ButtonImage2, a_ButtonText;
    public Animator a_BackArrow;
    public Image i_ButtonImage2;
    public UI_OptionsButton optionsButton;
    public UI_MenuButton otherButton, otherButton1;

    public float alphaFade;
    public float submenuFade;
    public bool Open;

    private float submenuTargetAlpha;
    private float arrowTargetAlpha;
    public CanvasGroup myGroup;
    private bool hasExited;
    void Start()
    {

    }

    void Update()
    {
        if (SubmenuGroup.alpha != submenuTargetAlpha)
        {
            SubmenuGroup.alpha = Mathf.Lerp(SubmenuGroup.alpha, submenuTargetAlpha, Time.deltaTime * alphaFade);
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
            a_ButtonImage.SetBool("hold", true);
            a_ButtonImage2.SetBool("hold", true);
            a_ButtonText.SetBool("hold", true);
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        hasExited = true;
        if (!Open)
        {
            a_ButtonImage.SetBool("hold", false);
            a_ButtonImage2.SetBool("hold", false);
            a_ButtonText.SetBool("hold", false);
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (hasExited)
        {
            hasExited = false;
            return;
        }

        a_ButtonImage.SetBool("hold", false);
        a_ButtonImage2.SetBool("hold", false);
        a_ButtonText.SetBool("hold", false);


        if (!Open)
        {
            otherButton.enabled = false;
            otherButton1.enabled = false;
            StopAllCoroutines();
            StartCoroutine("OpenSubmenu");
            Open = true;

        }
    }


    IEnumerator OpenSubmenu()
    {
        //alphaFade = 10;

        ButtonGroup.alpha = 1;
        optionsButton.enabled = false;
        i_ButtonImage2.color = Color.clear;
        ArrowGroup.gameObject.SetActive(true);
        a_ButtonImage.SetBool("isOpen", true);
        a_ButtonImage2.SetBool("isOpen", true);
        a_ButtonText.SetBool("isOpen", true);

        yield return new WaitForSeconds(submenuFade);
        submenuTargetAlpha = 1;
        arrowTargetAlpha = 1;
        a_BackArrow.ResetTrigger("close");
        a_BackArrow.SetTrigger("open");
        yield return new WaitForSeconds(.125f);
        LogoButton.Enabled = false;
        SubmenuGroup.gameObject.SetActive(true);




    }
    IEnumerator CloseSubmenu()
    {
        //alphaFade = 20;
        LogoButton.Enabled = true;
        Open = false;
        optionsButton.enabled = true;
        a_ButtonImage.SetBool("isOpen", false);
        a_ButtonImage2.SetBool("isOpen", false);
        a_ButtonText.SetBool("isOpen", false);
        a_BackArrow.ResetTrigger("open");
        a_BackArrow.SetTrigger("close");
        submenuTargetAlpha = 0;
        yield return new WaitForSeconds(.15f);
        arrowTargetAlpha = 0;
        yield return new WaitForSeconds(.15f);
        ArrowGroup.gameObject.SetActive(false);
        SubmenuGroup.gameObject.SetActive(false);
        i_ButtonImage2.color = Color.white;
        ButtonGroup.alpha = 0;
        otherButton.enabled = true;
        otherButton1.enabled = true;


    }
}
