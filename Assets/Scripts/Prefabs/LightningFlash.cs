using UnityEngine;
using System.Collections;

/// <summary>
/// for a lightning flash in the background of the main menu, maybe used in game as well?
/// </summary>

public class LightningFlash : MonoBehaviour {
    public Light thisLight;
    public float Timer;
    float initTimer;
	// Use this for initialization
	void Start () {
       
        thisLight.intensity = 0;
        initTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Timer = Random.Range(0, 4);
            thisLight.intensity = 1.65f;
            //play lightning audio clip (or if you want more realistic, make the sound go off a second before the flash)
        }
        else {
            thisLight.intensity = 0.0f;
        }

        Debug.Log("Timer " + Timer);
	}
}
