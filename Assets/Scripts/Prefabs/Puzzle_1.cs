using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puzzle_1 : MonoBehaviour {
    //if you init in the editor area (aka , here)  then it will make the editor show what you inited rather than let you do
    //what you wanted and then just override it later
    public ObjectSwitchTemplate[] arrayOfTemplates = new ObjectSwitchTemplate[4]; 

    //does it need to be public ?
    Transform[] arrayOf_TemplateSockets = new Transform[4];

    public Transform[] arrayOf_GO_Pos = new Transform[4];

    //determines if the dim1 object or dim2 object is going to be showing
    public bool dim1Showing;
    // should rotate the objects to the next location going counter clockwise
    public bool rotateThings;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < arrayOfTemplates.Length; i++)
        {
            //setting the sockets pos to the GO's pos
            arrayOf_TemplateSockets[i] = arrayOf_GO_Pos[i];
        }


        for (int i = 0; i < arrayOfTemplates.Length; i++)
        {
            //init'ing the sets to the sockets
            arrayOfTemplates[i].transform.position = arrayOf_TemplateSockets[i].transform.position;
        }
        rotateThings = false;
        dim1Showing = false;


       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.T))
            rotateThings = true;

        //make sure that all of the bools in the templates obey the "Master bool" / the dim1Showing bool
        for (int i = 0; i < arrayOfTemplates.Length; i++)
        {
            arrayOfTemplates[i].Dim1InView = dim1Showing;
        }

        if (rotateThings == true)
        {
            Debug.Log("Im rotating things!");
            RotateStuff();
            rotateThings = false;
        }

        //try and rotate the sets to the next position

        for (int i = 0; i < arrayOf_TemplateSockets.Length; i++)
        {
            //init'ing the sets to the sockets
            arrayOfTemplates[i].transform.position = arrayOf_TemplateSockets[i].transform.position;
        }

    }

    //should only rotate things once
    void RotateStuff()
    {
        for (int i = 0; i < arrayOf_TemplateSockets.Length; i++)
        {
            if (arrayOf_TemplateSockets[i].position == arrayOf_GO_Pos[3].position) // pos 3
            {
                arrayOf_TemplateSockets[i].position = arrayOf_GO_Pos[0].position;
            }
            else if (arrayOf_TemplateSockets[i].position == arrayOf_GO_Pos[2].position) // pos 2
            {
                arrayOf_TemplateSockets[i].position = arrayOf_GO_Pos[3].position;
            }
            else if (arrayOf_TemplateSockets[i].position == arrayOf_GO_Pos[1].position) // pos 1
            {
                arrayOf_TemplateSockets[i].position = arrayOf_GO_Pos[2].position;
            }
            else if(arrayOf_TemplateSockets[i].position == arrayOf_GO_Pos[0].position) // pos 0
            {
                arrayOf_TemplateSockets[i].position = arrayOf_GO_Pos[1].position;
            }
        }


            
        

   

     

        //for (int i = 0; i < arrayOfTemplates.Length; i++)
        //{
        //    if (i + 1 == 4)
        //    {
        //        arrayOfTemplates[i].transform.position = arrayOf_TemplateSockets[0].position;
            
        //    }
        //    else if(i + 1 < arrayOfTemplates.Length)
        //    {
        //        Debug.Log("I am going to the next object! bc i am in the last index of the socket");
        //        arrayOfTemplates[i].transform.position = arrayOf_TemplateSockets[i + 1].transform.position;
        //    }
        //}

        //for (int i = 0; i < arrayOfTemplates.Length; i++)
        //{
        //    if (arrayOfTemplates[i].transform.position == array_GO_Transforms[3].position)
        //    {
        //        arrayOfTemplates[i].transform.position = array_GO_Transforms[0].position;
        //    }
        //    else 
        //    {
        //        arrayOfTemplates[i].transform.position = array_GO_Transforms[i + 1].position;
        //    }
        //}


        //for (int i = 0; i < arrayOfTemplates.Length; i++)
        //{
        //    if (array_GO_Transforms[i] == array_GO_Transforms[3])
        //    {
        //        array_GO_Transforms.SetValue(array_GO_Transforms[3], 0);
        //    }else
        //    arrayOfTemplates[i].transform.position = array_GO_Transforms[i + 1].transform.position;
        //}
        
    }
}
