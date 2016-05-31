using UnityEngine;
using System.Collections;
/// <summary>
/// This is the rotation wheel that will rotate the key object in either a circle motion or oval esc... 
/// </summary>
public class Rotation_Wheel : MonoBehaviour {
    //the actual gameObject for the rotating wheel
    public GameObject rot_wheel;

    //Animations that the wheel will be preforming
    public Animation rot_jammed;
    public Animation rot_spin;

    public bool isSpinning;

	// Use this for initialization
	void Start () {
        //the jammed animation should play first
        isSpinning = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isSpinning)
        {

            rot_spin.Play();
        }
        else {
            rot_jammed.Play();
        }
	
	}
}
