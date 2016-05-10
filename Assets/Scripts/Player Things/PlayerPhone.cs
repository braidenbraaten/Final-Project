using UnityEngine;
using System.Collections;

public class PlayerPhone : MonoBehaviour {
    public Light phoneFlashlight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            //switches between on and off for the flashlight... light
            phoneFlashlight.enabled = !(phoneFlashlight.enabled);
        }

	}
}
