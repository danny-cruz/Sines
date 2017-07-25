using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_Leaderboard : MonoBehaviour
{

    private SpriteRenderer SpriteRend;
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    public Color AlphaGrey;
    public Color Grey;
    public OptionsButton optionsButton;
    public GPG_SignIn GPG_signIn;
    public Text text;
    public SpriteRenderer IconSpriteRend;
    public GPGButton gpgButton;

    private Color AlphaLerp;
    private Color WhiteLerp;

    private int OpenSpeed = 5;
    private int CloseSpeed = 30;

    private bool Pressed;

    private Vector3 StartScale;
    private Vector3 TargetScale;
    // Use this for initialization
    void Awake()
    {
        SpriteRend = GetComponent<SpriteRenderer>();

        if (GPG_signIn.SignIn)
        {
            SpriteRend.color = Alpha;
        }
        else
            SpriteRend.color = AlphaGrey;

        StartScale = transform.localScale;
        TargetScale = new Vector3(transform.localScale.x * .95f, transform.localScale.y * .95f, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gpgButton.OpenSubmenu)
        {
            if (GPG_signIn.SignIn)
            {
                AlphaLerp = Alpha;
            }
            else if (!GPG_signIn.SignIn)
            {
                AlphaLerp = AlphaGrey;
            }
            SpriteRend.color = AlphaLerp;
            text.color = Alpha;
            text.enabled = false;
            IconSpriteRend.color = Alpha;
            this.gameObject.SetActive(false);
        }

        else if (!optionsButton.xDelay && gpgButton.OpenSubmenu)
        {
            if (!Pressed)
            {
                if (GPG_signIn.SignIn)
                {
                    WhiteLerp = Color.Lerp(SpriteRend.color, ButtonUpColor, Time.deltaTime * OpenSpeed);
                }
                else if (!GPG_signIn.SignIn)
                {
                    WhiteLerp = Color.Lerp(SpriteRend.color, Grey, Time.deltaTime * OpenSpeed);
                }
                transform.localScale = Vector3.Lerp(transform.localScale, StartScale, Time.deltaTime * 15);
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

        if (!GPG_signIn.SignIn || !gpgButton.OpenSubmenu)
        {
            return;
        }
        if (Input.GetButtonDown("Touch"))
        {
            Pressed = true;
            SpriteRend.color = ButtonDownColor;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (GPG_signIn.SignIn)
            {
                if (Pressed)
                {
                    PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIlu2Nm5MWEAIQBw");
                    Pressed = false;
                    SpriteRend.color = ButtonUpColor;
                }
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
