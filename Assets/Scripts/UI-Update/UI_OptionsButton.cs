using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_OptionsButton : MonoBehaviour, IPointerDownHandler
{
    public OptionsButton optionsButton;
    public Controller controller;
    public Animator highScoreTextAnimator;

    public GameObject Menu;

    public Animator circleAnimator;
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
        circleAnimator.SetTrigger("click");
    }
    void Update () 
	{

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
        menuTargetAlpha = 1;
    }
}
