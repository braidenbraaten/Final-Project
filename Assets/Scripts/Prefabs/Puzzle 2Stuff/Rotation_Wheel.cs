using UnityEngine;
using System.Collections;
/// <summary>
/// This is the rotation wheel that will rotate the key object in either a circle motion or oval esc... 
/// </summary>
public class Rotation_Wheel : MonoBehaviour {
    public RunwayLights runwayLights;
    public bool hasStarted = false;
    public bool hasEnded = false;
    public bool dropped = false;
    public float dropTimer = 0.0f;
    private float prevDropTimer;
    public GameObject Wheel;
    public Door puzzleDoor;
    //the keys
    public GameObject keys;
    //the position of the keys
    //public Transform Keypos;
    //the position on the wheel that we want to hold the keys
    public Transform targetKeyPos;
    //used for when we drop the keys
    private Transform prevKeyPos;
    public float rotSpeed = 20f;
    public float jamSpeed = 30f;


    void Start()
    {
        hasStarted = false;
        prevDropTimer = dropTimer;
        rot_speedIncrease = 16;
        
    }

    public void Update()
    {
        runwayLights.runLightProgram();
        prevKeyPos = targetKeyPos;

   

        //checks to see if we have gone through firstDrop yet
        if (hasStarted)
        {
            //rotates the wheel
            Rotate();

            if (hasEnded == true)
            {
                End();
            }
            //rotates the key object with the wheel
            //RotateKey();
        }
        else if(hasStarted == false){
            FirstDrop();
        }
    }

    //the function that will enact the first drop / first player interaction
    public void FirstDrop()
    {
        //makes the object slerp between two angle to look jammed
        if (hasStarted == false)
        {
            if (puzzleDoor.open == false) { JammedRotate(); }
        }
        //this will cause the if statement in update to go off
        if (puzzleDoor.open == true) { hasStarted = true;}
    }


    
    //function that allows the key to rotate with the wheel
    public void RotateKey()
    {

        
        keys.transform.position = targetKeyPos.position;
            keys.transform.forward = targetKeyPos.forward;

            //makes sure that the key is the child of the wheel
            targetKeyPos.SetParent(Wheel.transform);
      
        
        //targetKeyPos.RotateAround(Wheel.transform.position, Vector3.up, -rotSpeed * Time.deltaTime);
    }

    public void DropKey()
    {
        dropped = true;
        keys.transform.parent.SetParent(null);
        if (dropped) { dropTimer -= Time.deltaTime;}
        if (dropTimer <= 0)
        {
            dropTimer = prevDropTimer;
            dropped = false;
           

        }


        if (dropped == false)
        {
            ResetKey();
        }
    }

    // Rotation Speed Multiplier 
    private float rot_speedIncrease;

    public void ResetKey()
    {
        
        RotateKey();
        //keys.transform.position = targetKeyPos.position;
        //keys.transform.rotation = targetKeyPos.rotation;
        
    }

    
    public bool hasGrabbed = false;
    public void Grab()
    {
        hasGrabbed = true;
    }

    private bool rot_start = false;
    //should cause the wheel to spin counter clockwise
    public void Rotate()
    { 
        Wheel.transform.Rotate(0,-rotSpeed * Time.deltaTime * rot_speedIncrease, 0);
        if (rot_start == false)
        {
            if (hasStarted)
            {
                ResetKey();
                rot_start = true;
            }
        }

        if (rot_start == true)
        {
            if (puzzleDoor.open == false && hasGrabbed == false)
            {
                ResetKey();
            }

            if (puzzleDoor.open == true && hasGrabbed == true)
            {
                puzzleDoor.open = false;
                hasEnded = true;
            }
            

            
        }

    }

    public void End()
    {
        //This is where we can add the slowing down sound, and light shutdown
    }


    //the angles that the wheel lerps between
    public float fwdAngle;
    public float bwdAngle;
    //to tell if it needs to go back or forth
    private bool forth = true;
    //the rate at wich the wheel will go back and forth
    public float interpolSpeed;
    //keeps track of time.deltatime
    private float watchTimer;
    //the jamm function
    private void JammedRotate()
    {
        Quaternion forwardHit = Quaternion.Euler(0, fwdAngle, 0);
        Quaternion backHit = Quaternion.Euler(0, bwdAngle, 0);
        watchTimer += Time.deltaTime;
        if (watchTimer >= interpolSpeed)
        {
            forth = !forth;
            watchTimer = 0;
        }

        if (forth)
        {
            Wheel.transform.localRotation = Quaternion.Slerp(Wheel.transform.localRotation, forwardHit, jamSpeed * Time.deltaTime);
        }

        if (forth == false)
        {
            Wheel.transform.localRotation = Quaternion.Slerp(Wheel.transform.localRotation, backHit, jamSpeed * Time.deltaTime);
        }

        RotateKey();
    }
    //if the player interacts for the first time the keys drop and the lights go out
    

    //have a function for when the keys drop to cause the lights to go out and come back on 
    //and have the keys position reset before they come back on (so it looks like they 
    //just reappeared there).

    //-f jamm[*]
    //-f dropKey[]
    //-f startRotation[]
    //-f put key back on wheel[]
    //-f enable lanes[]
}
