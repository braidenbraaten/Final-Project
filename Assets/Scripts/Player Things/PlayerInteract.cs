using UnityEngine;
using System.Collections;

/// <summary>
/// This class mainly consists of the raycast that the player is constantly sending out
/// so they can interact with the objects in the world
/// </summary>

public class PlayerInteract : MonoBehaviour {
    public Camera playerCam;
    public Transform playerTransform;
    public Vector3 camRayOffPos;
    public Vector3 camRayRotationOffRot;
    public float rayDistance;
    Ray p1Ray;
    public bool puzzle1_Active;

    bool hasGrabed = false;

    //player pos off = 0,0,0
    //player rot off = .13, -0.22, 0.1

    // Use this for initialization

    RaycastHit hit;
    void Start () {
        
    }

    void FixedUpdate()
    {
        

        if (Physics.Raycast(p1Ray, out hit, rayDistance))
        {
            Debug.DrawLine(hit.point, hit.transform.up * 10);
            Debug.Log(hit.collider.gameObject.tag);
        }

        if (hit.collider.gameObject.tag == "Can Grab")
        {
            if (Input.GetKeyDown(KeyCode.G)){ hasGrabed = true;}
 
            

            
        }

        //if chapter 1 (or something like that) 
        if (puzzle1_Active == true)
        {
            //if we interact with the Till
            if (hit.collider.gameObject.tag == "Till")
            {
                GameObject.Find("Puzzle_1").BroadcastMessage("resetRotIndex");
                
                Debug.Log("the puzzle has reset");
            }


            //if we interact with the Toilet
            if (hit.collider.gameObject.tag == "Toilet")
            {
                GameObject.Find("Puzzle_1").BroadcastMessage("RotateRKey");
            }

            //if we interact with the TV
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

        if (hasGrabed == true)
        {

            GameObject.Find(hit.collider.gameObject.name).transform.SetParent(playerTransform);

        }
        else if (hasGrabed == false)
        {
            GameObject.Find(hit.collider.gameObject.name).transform.SetParent(null);
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            hasGrabed = false;
        }
        

    }
}
