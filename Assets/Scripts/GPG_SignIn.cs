using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_SignIn : MonoBehaviour {

	public float Speed;
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;

    public static bool SignIn;
	public int StaySignedIn;
	private SpriteRenderer SpriteRend;
	private bool Pressed;
	// Use this for initialization
	void Awake () {
		PlayGamesPlatform.Activate();
		SpriteRend = GetComponent<SpriteRenderer>();

		if(PlayerPrefs.GetInt("LoggedIn") == 1){
			SignIn = true;
			Social.localUser.Authenticate((bool success) => {
				
				
			});
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
	
		if(Input.GetKeyDown(KeyCode.Z))
        {
			SignIn = true;
		
		}

		if(Input.GetKeyDown(KeyCode.X))
        {
			SignIn = false;
			
		}

	    if(!Pressed)
        {
	        if(SignIn)
            {

		    }
		    if(!SignIn)
            {

		    }
		}
	}

	void OnMouseOver()
    {

		if(Input.GetButtonDown("Touch"))
        {

			Pressed = true;
            SpriteRend.color = ButtonDownColor;
  
		}

		if(Input.GetButtonUp("Touch"))
        {
            SpriteRend.color = ButtonUpColor;
            if (Pressed)
            {
			    if(!SignIn)
                {
			        Social.localUser.Authenticate((bool success) => 
                    {
				        if(success)
                        {
						    SignIn = true;
						    PlayerPrefs.SetInt("LoggedIn", 1);
				        }
				        else
                        {
					    Debug.Log("Failed");
				        }
			        });
			    }
			    if(SignIn)
                {
				    PlayGamesPlatform.Instance.SignOut();
				    SignIn = false;
				    PlayerPrefs.SetInt("LoggedIn", 0);
				}
				Pressed = false;
			}
		}
	}

    void OnMouseExit()
    {
        if (Pressed)
        {
            Pressed = false;
            SpriteRend.color = ButtonUpColor;
        }
    }
}
