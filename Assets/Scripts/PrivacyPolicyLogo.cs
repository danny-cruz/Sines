using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrivacyPolicyLogo : MonoBehaviour 
{
    public bool CHINABUILD;
    public SpriteRenderer Fader;
    private SpriteRenderer mySpriteRenderer;
    public Color TargetColor;
    public float RotationSpeed;
    public float ColorChangeSpeed;
    public float FadeSpeed;
    public float FadeDelay;
    private bool Fade;

    public bool unlocked;

    private void Awake()
    {
#if !UNITY_IOS
        Application.targetFrameRate = 60;

#else
        Application.targetFrameRate = 60;
#endif
    }
    void Start () 
	{
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	void Update () 
	{

        if (unlocked)
        {
            PlayerPrefs.SetInt("AcceptedTerms", 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * RotationSpeed);
            mySpriteRenderer.color = Color.Lerp(mySpriteRenderer.color, TargetColor, Time.deltaTime * ColorChangeSpeed);
          
        }

        if(Fade)
        {
            Fader.color = Color.Lerp(Fader.color, Color.black, Time.deltaTime * FadeSpeed);
        }
    }

    public IEnumerator DelayedFade ()
    {
        yield return new WaitForSeconds(FadeDelay);
        Fade = true;
        yield return new WaitForSeconds(.4f);
        if (CHINABUILD)
        {
            SceneManager.LoadScene("Android China", LoadSceneMode.Single);
        }

    }

    void AcceptedTerms ()
    {

    }
}
