﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //the player game object (overall player)
    public GameObject Player1;
    //the camera for the player
    public Camera playerCamera;
    //speed of player movement
    public float speed;
    //speed of player cam movement
    public float camSpeed;
    Rigidbody rb;
    Vector3 cameraMove;
    public float maxSpeed;

    //animation stuff
    //player Animator
    public Animator ani;
    

    private float rotationX;
    private float rotationY;

    Ray playerInteractRay;

    // Use this for initialization
    void Start () {

        Player1 = this.gameObject;
        rb = Player1.GetComponent<Rigidbody>();
    
        
        playerInteractRay = new Ray(Player1.transform.position, playerCamera.transform.root.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //  rb.velocity = movement * speed;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector3 force = new Vector3();
        if (movement.x > 0) force += Player1.transform.right * speed;
        else if (movement.x < 0) force += -Player1.transform.right * speed;

        if (movement.y > 0) force += Player1.transform.forward * speed;
        else if (movement.y < 0) force += -Player1.transform.forward * speed;

        force = Vector3.ClampMagnitude(force + rb.velocity, maxSpeed);

        //Jumping!  Make sure to change / add a limit to how far up you can jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            force.y += 200.0f;
            
        }

        rb.AddForce(force);

        ani.SetFloat("Speed", rb.velocity.magnitude);
    }


    void Update()
    {

        Debug.DrawRay(playerInteractRay.origin, playerInteractRay.direction, Color.red);
        
        //50 max on the camera rotation 310 max 
        rotationX += Input.GetAxis("Mouse X") * camSpeed;
        rotationY += -(Input.GetAxis("Mouse Y") * camSpeed);


        //Debug.Log("Mouse X" + rotationX + " " + "Mouse Y:" + rotationY );
        
        //playerCamera.transform.Rotate(-camMoveVertical * camSpeed, camMoveHorizontal * camSpeed, 0.0f);

        //Rotation left and right

        Player1.transform.rotation = Quaternion.identity;

        Player1.transform.Rotate(0.0f, rotationX, 0.0f);

        //camera move up and down 

        // if (playerCamera.transform.rotation.x >= 0 && playerCamera.transform.rotation.x <= 50)
        // {



        //      Work on camera Restraints!!!!

        // if(playerCamera.transform.rotation.x >= 0.0f && playerCamera.transform.rotation.x < 50 || playerCamera.transform.rotation.x > 310 && playerCamera.transform.rotation.x <= 360.0f || playerCamera.transform.rotation.x >= 0 && playerCamera.transform.rotation.x < 3 || playerCamera.transform.rotation.x <= 360 && playerCamera.transform.rotation.x > 357)

        if (rotationY <= 60 && rotationY >= -50)
        {
            playerCamera.transform.localRotation = Quaternion.identity;
            playerCamera.transform.Rotate(rotationY, 0.0f, 0.0f);
        }
      
      //  }
    }
    
}
