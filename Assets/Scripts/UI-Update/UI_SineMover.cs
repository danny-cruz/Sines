using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SineMover : MonoBehaviour
{
    public Vector3 ResetPosition;
    public float MaxPosition;
    public GameObject Sine;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y <= MaxPosition)
        {
            transform.localPosition = new Vector2(Sine.transform.localPosition.x, Sine.transform.localPosition.y + 386.3467f);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
