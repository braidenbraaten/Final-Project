using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puzzle_1 : MonoBehaviour {

    //the sets that contain the two different dim objects
    public ObjectSwitchTemplate[] Sets;
    

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

    }

    //the function that will rotate the sets 
    void RotateRKey()
    {
        if (Input.GetKeyUp(KeyCode.R) && rotationIndex < 4)
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
        if (Input.GetKeyUp(KeyCode.T))
        {
            for (int i = 0; i < Sets.Length; i++)
            {
                Sets[i].Dim1InView = !Sets[i].Dim1InView;
            }
        }
    }


    //this is a quick patch to our problem, if we have time to polish I sugest that we look for a more optimized solution
    void RotateSets(int rotationNum)
    {
        switch (rotationNum)
        {
            case 0:
                Sets[0].transform.position = Sockets[0].transform.position;
                Sets[1].transform.position = Sockets[1].transform.position;
                Sets[2].transform.position = Sockets[2].transform.position;
                Sets[3].transform.position = Sockets[3].transform.position;
                break;

            case 1:
                Sets[0].transform.position = Sockets[1].transform.position;
                Sets[1].transform.position = Sockets[2].transform.position;
                Sets[2].transform.position = Sockets[3].transform.position;
                Sets[3].transform.position = Sockets[0].transform.position;

                break;

            case 2:
                Sets[0].transform.position = Sockets[2].transform.position;
                Sets[1].transform.position = Sockets[3].transform.position;
                Sets[2].transform.position = Sockets[0].transform.position;
                Sets[3].transform.position = Sockets[1].transform.position;

                break;

            case 3:
                Sets[0].transform.position = Sockets[3].transform.position;
                Sets[1].transform.position = Sockets[0].transform.position;
                Sets[2].transform.position = Sockets[1].transform.position;
                Sets[3].transform.position = Sockets[2].transform.position;

                break;
        }
    }

    void resetRotIndex()
    {
        rotationIndex = 0;
    }

}
