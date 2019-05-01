using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionZoom : MonoBehaviour 
{
    public float horizontalResolution = 1080;
    public float scale;

    void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

    private void OnGUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / scale;
    }
}
