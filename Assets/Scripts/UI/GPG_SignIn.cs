using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
public class GPG_SignIn : MonoBehaviour {


    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public UI_OptionsButton optionsButton;

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

    private Vector3 StartScale;
    private Vector3 TargetScale;

    // Use this for initialization
    void Awake () {
		SpriteRend = GetComponent<SpriteRenderer>();
        StartScale = transform.localScale;
        TargetScale = new Vector3(transform.localScale.x * .95f, transform.localScale.y * .95f, transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!gpgButton.OpenSubmenu)
        {
            AlphaLerp = Color.Lerp(SpriteRend.color, Alpha, Time.deltaTime * CloseSpeed);

            SpriteRend.color = Alpha;
            text.color = Alpha;
            text.enabled = false;
            IconSpriteRend.color = Alpha;
            this.gameObject.SetActive(false);
        }

        else if (!optionsButton.xDelay && gpgButton.OpenSubmenu)
        {
            if (!Pressed)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, StartScale, Time.deltaTime * 15);
                WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);

                SpriteRend.color = WhiteLerp;
                text.enabled = true;
                text.color = Color.white;
                IconSpriteRend.color = Color.white;
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Time.deltaTime * 15);
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
#if !NO_GPGS
				    PlayGamesPlatform.Instance.SignOut();
#endif
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
