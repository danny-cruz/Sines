using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ScoreCounter : MonoBehaviour 
{
    public int Score;
    private TextMeshProUGUI textMeshPro;

    void Start () 
	{
        textMeshPro = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("AddOne", 0, .1f);
    }
	
	void Update () 
	{
        textMeshPro.text = Score.ToString();

    }

    void AddOne()
    {
        Score += 1;
    }
}
