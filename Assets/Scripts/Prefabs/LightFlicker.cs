using UnityEngine;
using System.Collections;

/// <summary>
/// try to get the lights to flicker 
/// </summary>

public class LightFlicker : MonoBehaviour {
    public Light inputLight;
    public float waitTimer;
    public Vector2 BrightnessRange;
    float lightIntensValue;
    float initTimer;
	// Use this for initialization
	void Start () {
        StartCoroutine("flickLight");
        initTimer = waitTimer;
	}
	
	// Update is called once per frame
	void Update () {
        
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0)
        {
            waitTimer = initTimer;
            StartCoroutine("flickLight");
        }

       
        
        //inputLight.intensity = lightIntensValue;
        
      
	}
  

    //makes this into a coroutine 
   IEnumerator flickLight()
    {
        // 0 & .3
        //code things
        inputLight.intensity = Random.Range(BrightnessRange.x, BrightnessRange.y);
        //wait
        yield return new WaitForSeconds(.5f);
        //then do these code things
        inputLight.intensity = BrightnessRange.y;


    }
}
