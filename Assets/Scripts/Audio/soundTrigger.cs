using UnityEngine;
using System.Collections;

// When the gameobject trigger is activated, plays a sound at a different position
public class soundTrigger : MonoBehaviour
{

    public GameObject triggerCube;
    public AudioClip sound;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(sound, new Vector3(7, 0.5f, 12), 1.0f);
    }

    void OnTriggerExit(Collider other)
    {
      
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
