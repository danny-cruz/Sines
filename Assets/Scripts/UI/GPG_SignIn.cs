using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
public class GPG_SignIn : MonoBehaviour {


    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public OptionsButton optionsButton;

    public bool SignIn;
	public int StaySignedIn;
    public Text text;
    public SpriteRenderer IconSpriteRend;
    public GPGButton gpgButton;

    private Color AlphaLerp;
    private Color WhiteLerp;

    private int OpenSpeed = 5;
    private int CloseSpeed = 30;
    private SpriteRenderer SpriteRend;
	private bool Pressed;
    
	// Use this for initialization
	void Awake () {
		SpriteRend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!gpgButton.OpenSubmenu)
        {
            AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);

            SpriteRend.color = Alpha;
            text.color = Alpha;
            IconSpriteRend.color = Alpha;
            this.gameObject.SetActive(false);
        }

        else if (!optionsButton.xDelay && gpgButton.OpenSubmenu)
        {
            if (!Pressed)
            {
                WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);

                SpriteRend.color = WhiteLerp;
                text.color = Color.white;
                IconSpriteRend.color = Color.white;
            }
        }
	}

	void OnMouseOver()
    {

        if (!gpgButton.OpenSubmenu)
        {
            return;
        }

        if (Input.GetButtonDown("Touch"))
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
                            text.text = "Sign Out";
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
                    text.text = "Sign In";
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
            //SpriteRend.color = ButtonUpColor;
        }
    }
}
