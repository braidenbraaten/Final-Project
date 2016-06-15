using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// We want to have the lights go on and off in opposite order  0101010101
/// </summary>


public class RunwayLights : MonoBehaviour {

    //list of the lights
    public List<RunLight> lightList;
    private Color lightStartColor;

    //the timer for when the lights will flash after the keys fall into the void
    public float wrongFlashTimer;
    private float prevWrongTimer;

    //starting time and timer for light flash rotator
    public  float FlashTimer;
    private float prevTimer;

    //if the keys fell bellow / hit the collider of the void section
    public bool missed = false;

    //bool to check if the light is on
    private bool light_on = false;

    //have it be different for each instance of the game for what light is on, and which light is off
    private int startLightValue;

    void Start()
    {

        lightStartColor = lightList[0].myLight.color;
        startLightValue = Random.Range(0, 1);

        prevTimer = FlashTimer;
        prevWrongTimer = wrongFlashTimer;

        if (startLightValue == 1)
        {
            light_on = true;
        }
        else if (startLightValue == 0)
        {
            light_on = false;
        }

        if (light_on)
        {
            lightList[0].isOn = true;
            lightList[1].isOn = false;
            lightList[2].isOn = true;
            lightList[3].isOn = false;
        }
        else {
            lightList[0].isOn = false;
            lightList[1].isOn = true;
            lightList[2].isOn = false;
            lightList[3].isOn = true;
        }

    }
    

    public void Update()
    {
        if (missed)
        {
            InVoid();
        }
        else {CycleLights();}
    }

    //make the lights flash at you, unless you miss
    public void CycleLights()
    {
        FlashTimer -= Time.deltaTime;

        if (FlashTimer < 0)
        {
            for (int i = 0; i < lightList.Count; i++)
            {
                lightList[i].myLight.color = lightStartColor;
                lightList[i].isOn = !lightList[i].isOn;
            }
            FlashTimer = prevTimer;
        }
    }

    // triggered when the Keys collide with the invis wall
    public void InVoid()
    {
        //timer countdown
        wrongFlashTimer -= Time.deltaTime;
        //play sound here 

        //have the lights turn on and off
        if (wrongFlashTimer < 0)
        {
            for (int i = 0; i < lightList.Count; i++)
            {
                lightList[i].myLight.color = Color.red;
                lightList[i].isOn = !lightList[i].isOn;
            }
            wrongFlashTimer = prevWrongTimer;
        }

    }

    public void TurnOffLights()
    {
        for (int i = 0; i < lightList.Count; i++)
        {
            lightList[i].isOn = false;
        }
    }

}
