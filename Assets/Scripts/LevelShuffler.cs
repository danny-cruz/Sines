using UnityEngine;
using System.Collections;

public class LevelShuffler : MonoBehaviour {
	public GameObject[] SuperEasyLevels;
	public GameObject[] EasyLevels;
	public GameObject[] MediumLevels;
	public GameObject[] HardLevels;

	internal int LevelSuperEasy;
	internal int LevelEasy;
	internal int LevelMedium;
	internal int LevelHard;

	internal GameObject NextSuperEasy;
	internal GameObject NextEasy;
	internal GameObject NextMedium;
	internal GameObject NextHard;

	// Use this for initialization
	void Start () {
		Shuffle(SuperEasyLevels);
		Shuffle(EasyLevels);
		Shuffle(MediumLevels);
		Shuffle(HardLevels);
	}
	
	// Update is called once per frame
	void Update () {
		NextSuperEasy = SuperEasyLevels[LevelSuperEasy];
		NextEasy = EasyLevels[LevelEasy];
		NextMedium = MediumLevels[LevelMedium];
		NextHard = HardLevels[LevelHard];


	

		if(LevelEasy == 20){
			LevelEasy = 0;
			Shuffle(EasyLevels);
		}

		if(LevelMedium == 22){
			LevelMedium = 0;
			Shuffle(MediumLevels);
		}

		if(LevelHard == 16){
			LevelHard = 0;
			Shuffle(HardLevels);
		}
	}

	void Shuffle(GameObject[] Levels)
	{

		for (int t = 0; t < Levels.Length; t++ )
		{
			GameObject tmp = Levels[t];
			int r = Random.Range(t, Levels.Length);
			Levels[t] = Levels[r];
			Levels[r] = tmp;
		}
	}
}
