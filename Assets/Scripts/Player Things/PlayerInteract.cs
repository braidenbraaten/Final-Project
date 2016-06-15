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
    //puzzle stuff
    public bool puzzle1_Active;
    public bool puzzle2_Active;

    public KeyCode grabCode;
    public KeyCode letGoCode;

    bool hasGrabed = false;

    //player pos off = 0,0,0
    //player rot off = .13, -0.22, 0.1

    // Use this for initialization


    public Animator ani;
    
    //The hit info that we will receive from the raycast
    public RaycastHit hit;
    void Start () {

        
    }

    void FixedUpdate()
    {
        

        if (Physics.Raycast(p1Ray, out hit, rayDistance))
        {
            Debug.DrawLine(hit.point, hit.transform.up * 10);
            Debug.Log(hit.collider.gameObject.tag);
        }

        //if we are hitting something and not nothing
        if (hit.collider != null)
        {
            //for any object that we can grab
            if (hit.collider.gameObject.tag == "Can Grab")
            {
                if (Input.GetKeyDown(grabCode)) {
                    ani.SetTrigger("grab");

                    hasGrabed = true;
                    
                }

                


            }



            //if chapter 1 (or something like that) 
            if (puzzle1_Active == true)
            {
                

                //if we interact with the Till
                if (hit.collider.gameObject.tag == "Till")
                {
                    //reset the sets
                    GameObject.Find("Puzzle_1").BroadcastMessage("resetRotIndex");


                }


                //if we interact with the Toilet
                if (hit.collider.gameObject.tag == "Toilet")
                {
                    //rotate the sets
                    GameObject.Find("Puzzle_1").BroadcastMessage("RotateRKey");
                }

                //if we interact with the TV
                if (hit.collider.gameObject.tag == "TV")
                {
                    //switch the sets
                    GameObject.Find("Puzzle_1").BroadcastMessage("switchDimTKey");
                    
                }
            }

            //if puzzle 2 is active
            if (puzzle2_Active == true)
            {  //if we collide with the key and grab the keys
                if (hit.collider.gameObject == GameObject.Find("KeyObject") || hit.collider.gameObject == GameObject.Find("Key") && Input.GetKeyDown(grabCode))
                {
                    //end the puzzle and start the next
                    
                }
            }
            
            

        }

    }

	// Update is called once per frame
	void Update () {
        //the ray that the player uses to interact with things
        p1Ray.origin = playerCam.transform.position + camRayOffPos;
        p1Ray.direction = playerCam.transform.forward + camRayRotationOffRot;
        Debug.DrawRay(p1Ray.origin, p1Ray.direction * rayDistance, Color.red);

        if (hit.collider)
        {

            //grabbing the object
            if (hasGrabed == true)
            {
                GameObject.Find(hit.collider.gameObject.name).transform.SetParent(playerCam.transform);
                if(hit.collider.gameObject.GetComponent<Rigidbody>())
                GameObject.Find(hit.collider.gameObject.name).GetComponent<Rigidbody>().isKinematic = true;

            }
            //letting go of the object    // MAKE SURE THAT THE OBJECT IS A GRABABLE OBJECT THAT WE ARE SETTING THE PARENT TO NULL FOR !!!!!!!!!!!!!!!!!!!!
            else if (hasGrabed == false && hit.collider.gameObject.tag == "Can Grab")
            {   GameObject.Find(hit.collider.gameObject.name).transform.SetParent(null);
                //asks if the object is already kinematic, and if so, then set it to false (so gravity will work on it again)

                if (hit.collider.gameObject.GetComponent<Rigidbody>())
                {
                    if (GameObject.Find(hit.collider.gameObject.name).GetComponent<Rigidbody>().isKinematic == true)
                    {
                        GameObject.Find(hit.collider.gameObject.name).GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            }

            if (Input.GetKeyUp(letGoCode))
            {
                hasGrabed = false;
                ani.SetBool("hasGrabed", false);
            }

        }
    }
}
