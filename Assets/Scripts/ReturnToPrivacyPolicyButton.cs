using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToPrivacyPolicyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{

    public Color Grey;
    public Color Alpha;
    public float ColorChangeSpeed;
    private Color targetColor;
    public bool Enabled;
    private bool unlocked;
    private bool hasExited;
    private Image myImage;


    void Start()
    {
        myImage = GetComponent<Image>();
        targetColor = Alpha;
    }

    void Update()
    {
        if(myImage.color != targetColor)
        {
            myImage.color = Color.Lerp(myImage.color, targetColor, Time.deltaTime * ColorChangeSpeed);
        }
        if(Enabled)
        {
            targetColor = Grey;
        }
        else
        {
            targetColor = Alpha;
        }

        if(unlocked)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -180), Time.deltaTime * 8);
            StartCoroutine("DelayedFade");
        }
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
        else
        {
            if(Enabled)
            {
                unlocked = true;
            }
        }
    }

    public IEnumerator DelayedFade()
    {

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene("Terms China", LoadSceneMode.Single);

    }
}