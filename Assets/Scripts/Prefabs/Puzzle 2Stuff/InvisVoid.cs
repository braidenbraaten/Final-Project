using UnityEngine;
using System.Collections;


public class InvisVoid : MonoBehaviour {

    public Collider keyCollider;
    public RunwayLights myLights;
    public AudioSource failSound;
    

    //the Invis wall collider
    private Collider myCollider;
    //private Collision collision;
	// Use this for initialization
	void Start () {
        //myLights = GameObject.Find("RunwayLights").GetComponent<RunwayLights>();
        myCollider = this.GetComponent<Collider>();
        keyCollider = keyCollider.gameObject.GetComponent<Collider>();
	}

    // when the keys collid with the void wall, then do...
    void OnCollisionEnter(Collision collision) {
        if (collision.collider == keyCollider)
        {
            //makes the lights turn red and flicker faster
            myLights.missed = true;

            
            failSound.Play();
        }
    }
    void OnCollisionExit(Collision collisionInfo) {myLights.missed = false;}
}
