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

			else if(Score >= 75 && Score < 450){ 

				NextLevelEasy.transform.position = EndPoint.transform.position;
				NextLevelEasy.SetActive(true);
				levelShuffler.LevelEasy++;
			}

            else if(Score >= 450 && Score < 1450){ 
				
				if(Easy){

					NextLevelMedium.transform.position = EndPoint.transform.position;
					NextLevelMedium.SetActive(true);
					levelShuffler.LevelMedium++;
				}
				
				else if(Medium){

					NextLevelEasy.transform.position = EndPoint.transform.position;
					NextLevelEasy.SetActive(true);
					levelShuffler.LevelEasy++;
				}
			}

            else if (Score >= 1450 && Score < 1750){

				NextLevelMedium.transform.position = EndPoint.transform.position;
				NextLevelMedium.SetActive(true);
				levelShuffler.LevelMedium++;
				
			}

            else if (Score >= 1750 && Score < 2750)
            {
				if(Hard){

                    NextLevelEasy.transform.position = EndPoint.transform.position;
                    NextLevelEasy.SetActive(true);
                    levelShuffler.LevelEasy++;
                }
				
				else if(Medium){

                    NextLevelHard.transform.position = EndPoint.transform.position;
                    NextLevelHard.SetActive(true);
                    levelShuffler.LevelHard++;
                }
				
				else if(Easy){
				
                    NextLevelMedium.transform.position = EndPoint.transform.position;
                    NextLevelMedium.SetActive(true);
                    levelShuffler.LevelMedium++;
                }
				
			}

            else if (Score >= 2750 && Score < 4500){
				if(Hard){

					NextLevelMedium.transform.position = EndPoint.transform.position;
					NextLevelMedium.SetActive(true);
					levelShuffler.LevelMedium++;;
				}
				
				else if(Medium){

					NextLevelHard.transform.position = EndPoint.transform.position;
					NextLevelHard.SetActive(true);
					levelShuffler.LevelHard++;
				}
				
			}

            else if (Score >= 4500){

				NextLevelHard.transform.position = EndPoint.transform.position;
				NextLevelHard.SetActive(true);
					levelShuffler.LevelHard++;
			}
		}
	}
}
