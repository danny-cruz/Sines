﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ScoreCounter : MonoBehaviour {
	Text text;
	private string Achievement100 = "CgkIlu2Nm5MWEAIQAQ";
	private string Achievement500 = "CgkIlu2Nm5MWEAIQAg";
	private string Achievement1000 = "CgkIlu2Nm5MWEAIQAw";
	private string Achievement5000 = "CgkIlu2Nm5MWEAIQBA";
	private string Achievement10000 = "CgkIlu2Nm5MWEAIQBQ";
	private string Achievement20000 = "CgkIlu2Nm5MWEAIQBg";
	public int Score;
	public static bool Winner;


	// Use this for initialization
	void Start () {
	//	controller = Controller.GetComponent<Controller>();
		text = GetComponent<Text>();
		InvokeRepeating("AddOne", 0, .1f);

	}

	void AddOne (){
		if(!Controller.Lost){
		if(!OptionsButton.Pause){
		Score+=1;
			}
		}
	}

	void StoreHighscore(int newHighScore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighScore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighScore);
		Social.ReportScore(newHighScore, "CgkIlu2Nm5MWEAIQBw", (bool success) => {
		});

	}
	// Update is called once per frame
	void Update () {
		if(Controller.Lost){
			StoreHighscore(Score);
		
		if(Score >= 100 && Score < 500){



			Social.ReportProgress(Achievement100, 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if(Score >= 500 && Score < 1000){
			Social.ReportProgress(Achievement500, 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if(Score >= 1000 && Score < 5000){
			Social.ReportProgress(Achievement1000, 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if(Score >= 5000 && Score < 10000){
			Social.ReportProgress(Achievement5000, 100.0f, (bool success) => {
				// handle success or failure
			});
						
		}

		if(Score >= 10000 && Score < 20000){
			Social.ReportProgress(Achievement10000, 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if(Score >= 20000){
			Social.ReportProgress(Achievement20000, 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if(Score >= 5000){
				Winner = true;
			}

			if(Score < 5000){
				Winner = false;
			}
		}


		text.text = Score + " ";
	}
}