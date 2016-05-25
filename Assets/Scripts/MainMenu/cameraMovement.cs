using UnityEngine;
using System.Collections;

/// <summary>
/// trying to get the camera to move up, down, left, and right ever so slighty in idle
/// </summary>

public class cameraMovement : MonoBehaviour {
    public Camera cam;
    Vector3 targetPos;
    public float speed;
  
    Vector3 endPos = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
        //starting pos
        
       
	}
	
	// Update is called once per frame
	void Update () {

        // keeep 170 !
        if(cam.transform.position.y >= 170)
        cam.transform.position += Vector3.down;


      


    }

   
    
}
