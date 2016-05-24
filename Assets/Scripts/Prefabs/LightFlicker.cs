using UnityEngine;
using System.Collections;

/// <summary>
/// try to get the lights to flicker 
/// </summary>

public class LightFlicker : MonoBehaviour {
    public Light inputLight;
    public float waitTimer;
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

        //code things
        inputLight.intensity = Random.Range(0.0f, 8.0f);
        //wait
        yield return new WaitForSeconds(.5f);
        //then do these code things
        inputLight.intensity = 8.0f;


    }
}
