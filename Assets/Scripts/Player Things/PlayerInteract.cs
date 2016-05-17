using UnityEngine;
using System.Collections;

/// <summary>
/// This class mainly consists of the raycast that the player is constantly sending out
/// so they can interact with the objects in the world
/// </summary>

public class PlayerInteract : MonoBehaviour {
    public Camera playerCam;
    public Vector3 camRayOffPos;
    public Vector3 camRayRotationOffRot;
    public float rayDistance;
    Ray p1Ray;
    public bool puzzle1_Active;
   
    //player pos off = 0,0,0
    //player rot off = .13, -0.22, 0.1

	// Use this for initialization
	void Start () {
        
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(p1Ray, out hit, rayDistance))
        {
            Debug.DrawLine(hit.point, hit.transform.up * 10);
            Debug.Log(hit.collider.gameObject.tag);
        }

        if (puzzle1_Active == true)
        {
            if (hit.collider.gameObject.tag == "Till")
            {
                GameObject.Find("Puzzle_1").BroadcastMessage("resetRotIndex");
                
                Debug.Log("the puzzle has reset");
            }

            if (hit.collider.gameObject.tag == "Toilet")
            {
                GameObject.Find("Puzzle_1").BroadcastMessage("RotateRKey");
            }

            if (hit.collider.gameObject.tag == "TV")
            {
                GameObject.Find("Puzzle_1").BroadcastMessage("switchDimTKey");
            }
        }
            
        

    }

	// Update is called once per frame
	void Update () {

        p1Ray.origin = playerCam.transform.position + camRayOffPos;
        p1Ray.direction = playerCam.transform.forward + camRayRotationOffRot;
        Debug.DrawRay(p1Ray.origin, p1Ray.direction * rayDistance, Color.red);
       
        
        

    }
}
