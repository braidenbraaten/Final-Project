using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puzzle_1 : MonoBehaviour {

    //the sets that contain the two different dim objects
    public ObjectSwitchTemplate[] Sets;
    public KeyCode interactKey;
    public KeyCode rotateKey;
    public KeyCode switchKey;
    public Texture[] hotdogSetPics;
    public Texture[] moneySetPics;
    public Texture[] sandwichSetPics;
    public Texture[] voidSetPics;
    //TV screens, aka the planes that will display the textures
    public GameObject screen1;
    public GameObject screen2;


    //the sockets th
    public  Socket[] Sockets;
    //the current number of rotations that have occured 
    public int rotationIndex;

    void Start()
    {
        //sets to 0 so we can have a clean rotation
        rotationIndex = 0;
     

    }



    void Update()
    {
        
       

        //a function that will rotate the sets accordingly
        RotateSets(rotationIndex);

        for (int i = 0; i < Sets.Length; i++)
        {
            if (Sets[i].transform == Sockets[3])
            {
                //make the set that is currently at the TV's disapear and be replaced by two textures (1 for each TV)
            }
        }

    }

    //the function that will rotate the sets 
    void RotateRKey()
    {
        if (Input.GetKeyUp(rotateKey) && rotationIndex < 4)
        {
            rotationIndex += 1;
        }
        else if (rotationIndex >= 4)
        {
            rotationIndex = 0;
        }
    }

    //the function that will switch the sets from 1 dim to 2 dim
    void switchDimTKey()
    {
        if (Input.GetKeyUp(switchKey))
        {
            for (int i = 0; i < Sets.Length; i++)
            {
                Sets[i].Dim1InView = !Sets[i].Dim1InView;
            }
        }
    }

   
    void switchToSecondDim()
    {
        for (int i = 0; i < Sets.Length; i++)
        {
            Sets[i].Dim1InView = false;
        }
    }


    //this is a quick patch to our problem, if we have time to polish I sugest that we look for a more optimized solution
    void RotateSets(int rotationNum)
    {
        switch (rotationNum)
        {
            case 0:

                //hot dog and fingers
                Sets[0].transform.position = Sockets[0].transform.position;
                //moneys
                Sets[1].transform.position = Sockets[1].transform.position;
                //samwich and arm
                Sets[2].transform.position = Sockets[2].transform.position;
                //void
                Sets[3].transform.position = Sockets[3].transform.position;
                //make sure that the prev set that was in the socket is re-enabled and that the current set in the socket is disabled 
                Sets[3].enabled = false;
                Sets[0].enabled = true;

                if (Sets[3].Dim1InView == false)
                {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = voidSetPics[0];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = voidSetPics[1];
                }
                else {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = voidSetPics[1];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = voidSetPics[0];
                }
                break;

            case 1:
                Sets[0].transform.position = Sockets[1].transform.position;
                Sets[1].transform.position = Sockets[2].transform.position;
                Sets[2].transform.position = Sockets[3].transform.position;
                Sets[3].transform.position = Sockets[0].transform.position;

                //set 3 is enabled, set 2 is disabled 
                Sets[3].enabled = true;
                Sets[2].enabled = false;

                if (Sets[2].Dim1InView == false)
                {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = sandwichSetPics[0];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = sandwichSetPics[1];
                }
                else {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = sandwichSetPics[1];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = sandwichSetPics[0];
                }

                break;

            case 2:
                Sets[0].transform.position = Sockets[2].transform.position;
                Sets[1].transform.position = Sockets[3].transform.position;
                Sets[2].transform.position = Sockets[0].transform.position;
                Sets[3].transform.position = Sockets[1].transform.position;

                //set 2 is enabled and set 1 is disabled 
                Sets[2].enabled = true;
                Sets[1].enabled = false;

                if (Sets[1].Dim1InView == false)
                {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = moneySetPics[0];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = moneySetPics[1];
                }
                else {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = moneySetPics[1];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = moneySetPics[0];
                }
                break;

            case 3:
                Sets[0].transform.position = Sockets[3].transform.position;
                Sets[1].transform.position = Sockets[0].transform.position;
                Sets[2].transform.position = Sockets[1].transform.position;
                Sets[3].transform.position = Sockets[2].transform.position;

                //set 0 is disabled and set 1 is enabled 
                Sets[0].enabled = false;
                Sets[1].enabled = true;

                if (Sets[0].Dim1InView == false)
                {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = hotdogSetPics[0];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = hotdogSetPics[1];
                }
                else {
                    screen1.GetComponent<MeshRenderer>().material.mainTexture = hotdogSetPics[1];
                    screen2.GetComponent<MeshRenderer>().material.mainTexture = hotdogSetPics[0];
                }
                break;
        }
    }

    void resetRotIndex()
    {
        if (Input.GetKeyUp(interactKey))
        {
            Debug.Log("the sets have been reset");
            rotationIndex = 0;
            switchToSecondDim();
        }
    }

}
