using UnityEngine;
using System.Collections;

/// <summary>
/// trying to get the camera to move up, down, left, and right ever so slighty in idle
/// </summary>

public class cameraMovement : MonoBehaviour {
    public Camera cam;
    public float maxHeight;
    public float minHeight;

    bool goUp;
	// Use this for initialization
	void Start () {
        goUp = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (cam.transform.position.y > maxHeight)
        {
            flipDir();
        }

        if (cam.transform.position.y < minHeight)
        {
            flipDir();
        }
        
	}

    void flipDir() { goUp = !goUp; }
    
}
