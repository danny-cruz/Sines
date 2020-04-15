using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_OptionsButton : MonoBehaviour, IPointerDownHandler
{
    public ReturnToPrivacyPolicyButton PrivacyLogo;
    public OptionsButton optionsButton;
    public Controller controller;
    public Animator highScoreTextAnimator;

    public GameObject Menu;
    public GameOverText GameOver;
    public Animator circleAnimator;
    public Animator ellipsisAnimator0, ellipsisAnimator1, ellipsisAnimator2;
    public Animator x0, x1, x2, x3;
    public Animator xLine0, xLine1;
    private Button myButton;

    public CanvasGroup ImageGroup;
    public GraphicRaycaster ButtonGroup;
    public float MenuAlphaSpeed;
    private float menuTargetAlpha;
    public bool Open;
    public static bool Pause;

    public bool xDelay = true;
    void Start () 
	{
        Pause = false;
        controller.enabled = true;
        myButton = this.GetComponent<Button>();
        myButton.onClick.AddListener(TaskOnClick);
        

        Application.targetFrameRate = 60;
    }

    void OnApplicationPause()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        if (!Open)
        {
            OpenMenu();
        }
        else if (Open)
        {
            CloseMenu();
        }
        highScoreTextAnimator.SetBool("isOpen", Open);
        circleAnimator.SetBool("isOpen", Open);
        ellipsisAnimator0.SetBool("isOpen", Open);
        ellipsisAnimator1.SetBool("isOpen", Open);
        ellipsisAnimator2.SetBool("isOpen", Open);
        x0.SetBool("isOpen", Open);
        x1.SetBool("isOpen", Open);
        x2.SetBool("isOpen", Open);
        x3.SetBool("isOpen", Open);
        xLine0.SetBool("isOpen", Open);
        xLine1.SetBool("isOpen", Open);
        circleAnimator.SetTrigger("click");
    }
    void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            if (!Open)
            {
                OpenMenu();
            }
            else if (Open)
            {
                CloseMenu();
            }
            highScoreTextAnimator.SetBool("isOpen", Open);
            circleAnimator.SetBool("isOpen", Open);
            ellipsisAnimator0.SetBool("isOpen", Open);
            ellipsisAnimator1.SetBool("isOpen", Open);
            ellipsisAnimator2.SetBool("isOpen", Open);
            x0.SetBool("isOpen", Open);
            x1.SetBool("isOpen", Open);
            x2.SetBool("isOpen", Open);
            x3.SetBool("isOpen", Open);
            xLine0.SetBool("isOpen", Open);
            xLine1.SetBool("isOpen", Open);
            circleAnimator.SetTrigger("click");
        }

        if(ImageGroup.alpha != menuTargetAlpha)
        {
            ImageGroup.alpha = Mathf.Lerp(ImageGroup.alpha, menuTargetAlpha, Time.deltaTime * MenuAlphaSpeed);
        }

        highScoreTextAnimator.SetBool("Began", controller.Begin);
    }

    void TaskOnClick ()
    {

    }

    public void OpenMenu()
    {
        Pause = true;
        Open = true;
        
        ButtonGroup.enabled = true;
        StartCoroutine("OnPause");
    }
    public void CloseMenu()
    {
        Open = false;
        menuTargetAlpha = 0;
        if (GameOver.CHINABUILD)
        {
            PrivacyLogo.Enabled = false;
        }
        ButtonGroup.enabled = false;

        if (controller.Begin)
        {
            StartCoroutine("Unpause", .75f);
        }
        else if (!controller.Begin)
        {
            StartCoroutine("Unpause", .2f);
        }
    }

    IEnumerator Unpause(float Delay)
    {
        yield return new WaitForSeconds(Delay);

        Pause = false;

    }
    IEnumerator OnPause ()
    {
        yield return new WaitForSeconds(.2f);
        if (!controller.Begin)
        {
            if (GameOver.CHINABUILD)
            {
                PrivacyLogo.Enabled = true;
            }
        }
        menuTargetAlpha = 1;
    }
}
