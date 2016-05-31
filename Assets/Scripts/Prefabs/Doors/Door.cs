using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Door : MonoBehaviour {
    public string doorName;


    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float moveSpeed = 2f;
    public Transform transToRotate;
    //the actual 3d model of the door, aka the thing we are actually hitting
    public GameObject DoorModel;

    public KeyCode openDoorButton = KeyCode.F;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //having a bug that makes this object lose its parent transform, so this is the hotfix for the problem, can look into it later
        if (transform.parent == null)
            transform.SetParent(transToRotate);

        //is the door open or closed
        if (open)
        {
            Quaternion openRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transToRotate.localRotation = Quaternion.Slerp(transToRotate.localRotation, openRotation, moveSpeed * Time.deltaTime);
        }
        else
        {

            Quaternion closeRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transToRotate.localRotation = Quaternion.Slerp(transToRotate.localRotation, closeRotation, moveSpeed * Time.deltaTime);
        }

    }

    //allows the broadcast to change the door state from the raycast
    public void ChangeDoorState()
    {
        
        if (Input.GetKeyDown(openDoorButton))
            open = !open;
    }
}
