using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunwayLights : MonoBehaviour {
    public List<Light> lightList;
    private List<Light> prevLightList;
    public int amtOfFailFlashes;
    public bool fail = false;
	// Use this for initialization
	void Start () {
        prevLightList = lightList;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    bool lightOn = true;
    public void runLightProgram()
    {
        
        
        for (int i = 0; i < lightList.Count; i++)
        {
            lightOn = !lightOn;

            if (lightOn)
            {
                lightList[i].enabled = true;
            }

            if (lightOn == false)
            {
                lightList[i].enabled = false;
            }

        }
    }

    bool on = false;
    public void runLightFail()
    {
        //init the bool to turn the lights on and off 
        
        for (int i = 0; i < lightList.Count; i++)
        {
            lightList[i].color = Color.red;
        }

        for (int j = 0; j < amtOfFailFlashes; j++)
        {
            if (on == false)
            {
                for (int i = 0; i < lightList.Count; i++)
                {
                    lightList[i].enabled = false;
                }
                on = true;
            }
            else if (on)
            {
                for (int i = 0; i < lightList.Count; i++)
                {
                    lightList[i].enabled = true;
                }
                on = false;
            }
        }
    }



}
