using UnityEngine;
using System.Collections;
/// <summary>
/// This class holds the individual light associated with the runway lights
/// </summary>
public class RunLight : MonoBehaviour {
    public Light myLight;
    public Light prevLight;
    public bool isOn;
    // Use this for initialization

 

    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        CheckIfOn();

	}


   



    public void CheckIfOn()
    {
        if (isOn)
        {
            myLight.enabled = true;
        }
        else if (isOn == false)
        {
            myLight.enabled = false;
        }
        
    }
}
