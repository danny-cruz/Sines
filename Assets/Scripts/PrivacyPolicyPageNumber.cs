using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrivacyPolicyPageNumber : MonoBehaviour 
{
    public Color Grey;
    public Color Alpha;
    public int PageNumber;
    public GameObject[] Pages;
    public GameObject CurrentPage;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    private TextMeshProUGUI myText;

	void Start () 
	{
        myText = GetComponent<TextMeshProUGUI>();
        PageNumber = 1;
        CurrentPage = Pages[0];
    }
	
	void Update () 
	{
        myText.text = PageNumber + "/6";
		if(PageNumber < 1)
        {

        }
        else if (PageNumber == 1)
        {
            LeftArrow.SetActive(false);
            Pages[0].GetComponent<TextMeshProUGUI>().color = Grey;
            Pages[1].GetComponent<TextMeshProUGUI>().color = Alpha;
        }
        else if (PageNumber == 2)
        {
            LeftArrow.SetActive(true);
            Pages[0].GetComponent<TextMeshProUGUI>().color = Alpha;
            Pages[1].GetComponent<TextMeshProUGUI>().color = Grey;
            Pages[2].GetComponent<TextMeshProUGUI>().color = Alpha;
        }
        else if (PageNumber == 3)
        {
            Pages[1].GetComponent<TextMeshProUGUI>().color = Alpha;
            Pages[2].GetComponent<TextMeshProUGUI>().color = Grey;
            Pages[3].GetComponent<TextMeshProUGUI>().color = Alpha;
        }
        else if (PageNumber == 4)
        {
            Pages[2].GetComponent<TextMeshProUGUI>().color = Alpha;
            Pages[3].GetComponent<TextMeshProUGUI>().color = Grey;
            Pages[4].GetComponent<TextMeshProUGUI>().color = Alpha;
        }
        else if (PageNumber == 5)
        {
            RightArrow.SetActive(true);
            Pages[3].GetComponent<TextMeshProUGUI>().color = Alpha;
            Pages[4].GetComponent<TextMeshProUGUI>().color = Grey;
            Pages[5].GetComponent<TextMeshProUGUI>().color = Alpha;
        }
        else if (PageNumber == 6)
        {
            RightArrow.SetActive(false);
            Pages[4].GetComponent<TextMeshProUGUI>().color = Alpha;
            Pages[5].GetComponent<TextMeshProUGUI>().color = Grey;
        }
        else if (PageNumber > 6)
        {

        }
    }
}
