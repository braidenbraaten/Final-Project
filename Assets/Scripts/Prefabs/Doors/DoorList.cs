using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///                                 MAKE SURE TO HAVE ALL OF THE DOORS LISTED HERE!!!!!!!!!!!!!!
/// </summary>

public class DoorList : MonoBehaviour {
    public List<Door> doorList;
    public RaycastHit hitInfo;
    public PlayerInteract playerInteractScript;

    void Start () {

        for (int i = 0; i < doorList.Count; i++)
        {
            Debug.Log(doorList[i].doorName);
        }
	}
	

	void Update () {
        hitInfo = playerInteractScript.hit;
        //if we hit the door
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.tag == "Door")
            {
                //go through the doors and check wich one we hit
                for (int i = 0; i < doorList.Count; i++)
                {
                    //if the door is the same door we are hitting
                    if (doorList[i].doorName == hitInfo.collider.gameObject.GetComponentInParent<Door>().doorName)
                    {
                        //activate that door and that door only
                        doorList[i].ChangeDoorState();
                    }
                }
            }
        }
	}
}
