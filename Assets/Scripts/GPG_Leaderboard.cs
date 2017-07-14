using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG_Leaderboard : MonoBehaviour
{

    private SpriteRenderer SpriteRend;
    public Color Alpha;
    public Color ButtonUpColor;
    public Color ButtonDownColor;
    private bool SignedIn;
    private bool Pressed;
    // Use this for initialization
    void Start()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        SignedIn = GPG_SignIn.SignIn;

    }

    void OnMouseOver() 
    {

        if (Input.GetButtonDown("Touch")) {
            Pressed = true;
            SpriteRend.color = ButtonDownColor;
        }

        if (Input.GetButtonUp("Touch"))
        {
            if (SignedIn)
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
            SpriteRend.color = ButtonUpColor;
        }

    }
}
