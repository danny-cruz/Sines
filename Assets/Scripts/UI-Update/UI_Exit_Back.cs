using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Exit_Back : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public UI_ExitButton exitButton;
    private Animator myAnimator;

    private bool hasExited;

	void Start () 
	{
        myAnimator = GetComponent<Animator>();
    }
	
	void Update () 
	{
		
	}
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        hasExited = false;
        myAnimator.SetBool("hold", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasExited = true;
        myAnimator.SetBool("hold", false);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (hasExited)
        {
            hasExited = false;
            return;
        }
        myAnimator.SetBool("hold", false);
        myAnimator.SetTrigger("Close");
        exitButton.StartCoroutine("CloseSubmenu");
    }
}
