using UnityEngine;
using System.Collections;

public class CreateNextLevel : MonoBehaviour {
	private GameObject NextLevelSuperEasy;
	private GameObject NextLevelEasy;
	private GameObject NextLevelMedium;
	private GameObject NextLevelHard;
	private GameObject EndPoint;
	public GameObject Player;
	//public GameObject SegmentShuffler;
	public LevelShuffler levelShuffler;
	private int Score;
	public ScoreCounter scorecounter;
	//public GameObject Counter;
	public bool Easy;
	public bool Medium;
	public bool Hard;
	// Use this for initialization
	void Start () {
		//levelShuffler = SegmentShuffler.GetComponent<LevelShuffler>();
		//scorecounter = Counter.GetComponent<ScoreCounter>();
		EndPoint = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Score = scorecounter.Score;
		NextLevelSuperEasy = levelShuffler.NextSuperEasy;
		NextLevelEasy = levelShuffler.NextEasy;
		NextLevelMedium = levelShuffler.NextMedium;
		NextLevelHard = levelShuffler.NextHard;



		if(Player.transform.position.y > EndPoint.transform.position.y + 30){

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Player")){

			if(Score < 75){
				NextLevelSuperEasy.transform.position = EndPoint.transform.position;
				NextLevelSuperEasy.SetActive(true);
				if(levelShuffler.LevelSuperEasy < 2){
				levelShuffler.LevelSuperEasy++;
				}
			}

			if(Score >= 75 && Score < 750){

				NextLevelEasy.transform.position = EndPoint.transform.position;
				NextLevelEasy.SetActive(true);
				levelShuffler.LevelEasy++;
			}
			
			if(Score >= 750 && Score < 2000){
				
				if(Easy){

					NextLevelMedium.transform.position = EndPoint.transform.position;
					NextLevelMedium.SetActive(true);
					levelShuffler.LevelMedium++;
				}
				
				if(Medium){

					NextLevelEasy.transform.position = EndPoint.transform.position;
					NextLevelEasy.SetActive(true);
					levelShuffler.LevelEasy++;
				}
			}
			
			if(Score >= 2000 && Score < 2750){

				NextLevelMedium.transform.position = EndPoint.transform.position;
				NextLevelMedium.SetActive(true);
				levelShuffler.LevelMedium++;
				
			}
			
			if(Score >= 2750 && Score < 3250){
				if(Hard){

					NextLevelMedium.transform.position = EndPoint.transform.position;
					NextLevelMedium.SetActive(true);
					levelShuffler.LevelMedium++;
				}
				
				if(Medium){

					NextLevelEasy.transform.position = EndPoint.transform.position;
					NextLevelEasy.SetActive(true);
					levelShuffler.LevelEasy++;
				}
				
				if(Easy){
				
					NextLevelHard.transform.position = EndPoint.transform.position;
					NextLevelHard.SetActive(true);
					levelShuffler.LevelHard++;
				}
				
			}
			
			if(Score >= 3250 && Score < 4500){
				if(Hard){

					NextLevelMedium.transform.position = EndPoint.transform.position;
					NextLevelMedium.SetActive(true);
					levelShuffler.LevelMedium++;;
				}
				
				if(Medium){

					NextLevelHard.transform.position = EndPoint.transform.position;
					NextLevelHard.SetActive(true);
					levelShuffler.LevelHard++;
				}
				
			}
			
			if(Score >= 4500){

				NextLevelHard.transform.position = EndPoint.transform.position;
				NextLevelHard.SetActive(true);
					levelShuffler.LevelHard++;
			}
		}
	}
}
