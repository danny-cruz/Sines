using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool Lost;
	private bool Speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

		if(!Speed)
        {
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1, Time.deltaTime * .5f);
		}

		if(Speed)
        {
			Time.timeScale = Mathf.Lerp(Time.timeScale, 4, Time.deltaTime );
		}
	}

	IEnumerator SpeedUp(){

		Speed = true;
		yield return new WaitForSeconds(0.50f);
		Speed = false;
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Edge")){
			Lost = true;
		}

		if(other.tag.Equals("Boost")){
			StartCoroutine("SpeedUp");
		}
	}
}
