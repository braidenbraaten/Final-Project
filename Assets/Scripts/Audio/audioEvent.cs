using UnityEngine;
using System.Collections;

public class audioEvent : MonoBehaviour
{
    public AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

    void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }

    // Use this for initialization
    void Awake()
    {
        //if (audioSource == null)
           // audioSource = GameObject.Find("Godzilla").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
