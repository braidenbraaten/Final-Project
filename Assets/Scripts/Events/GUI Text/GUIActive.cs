using UnityEngine;
using System.Collections;


/// <summary>
/// This will make the game object osolate / fade in and out when the player enters within range of the collider

/// </summary>


public class GUIActive : MonoBehaviour {
    public bool IsGUIShowing;
    public GameObject textObject;
    public Light guiLight;
    float lightPulse;
    public float lightPulseTimer;
    public float timer;
    public AudioSource notifSound;


    float prevLightTimer;

    float resetTime;

    //should osolate between the two timers, one for making the object clear, and the other for making it re-appear
    bool timer1 = false;
    //only should be enabled if the player leaves and there is still time left to complete the cycle
    bool finishTime = false;

    void Start()
    {
        lightPulse = 0;

      //makes sure that the text doesnt appear / show until the player steps into it's range
        textObject.GetComponent<MeshRenderer>().enabled = false;

        prevLightTimer = lightPulseTimer;

        resetTime = timer;
        
    }

    

    //init the trigger
    void OnTriggerEnter()
    {

        //textObject.SetActive(true);
        textObject.GetComponent<MeshRenderer>().enabled = true;
        timer1 = true;
        finishTime = false;
        notifSound.Play();
        
        
    }

    //as the player stands within range of the collider
    void OnTriggerStay()
    {

        //makes it go transparent 
        if (timer1 == true)
        {
            textObject.GetComponent<TextMesh>().color = Color.Lerp(Color.red, Color.clear, timer);
            
        }

        //makes it reappear
        if (timer1 == false)
        {
            textObject.GetComponent<TextMesh>().color = Color.Lerp(Color.clear, Color.red, timer);
        }

        //when the timer hits 0
        if (timer < 0)
        {
            //switches the bool to the opposite of it's current true/false
            timer1 = !(timer1);

            //resets the timer to the init time
            timer = resetTime;
        }
        //the timer counts down
        timer -= Time.deltaTime;
    }

    void OnTriggerExit()
    {
        notifSound.Stop();

        if (timer > 0)
        {
            finishTime = true;
        }
        else finishTime = false;

        
        


    }


    bool lightUp = true;
   

    void Update()
    {
        lightPulseTimer -= Time.deltaTime;

        //resets the timer 
        if (lightPulseTimer <= 0)
            lightPulseTimer = prevLightTimer;
        
        if (lightUp == true || lightPulse <= 0)
        {
            lightPulse = Mathf.Lerp(0.0f, 6.0f, lightPulseTimer);
        }

        if (lightUp == false || lightPulse >= 6)
        {
            lightPulse = Mathf.Lerp(6.0f, 0.0f, lightPulseTimer);
        }
        guiLight.intensity = lightPulse;

        if (finishTime == true)
        {
            textObject.GetComponent<TextMesh>().color = Color.Lerp(Color.clear, Color.red, timer);
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = resetTime;
                finishTime = false;
                textObject.GetComponent<MeshRenderer>().enabled = false;

            }

        }

        
        
           
        

    }
}
