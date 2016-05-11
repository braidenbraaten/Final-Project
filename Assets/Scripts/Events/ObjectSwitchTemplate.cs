using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//This object should hold object 1 as the first dim object, and the second as the second dim object


public class ObjectSwitchTemplate : MonoBehaviour {
    
    //the objects in the set / 1 object from each dim.
    public GameObject dim1Object;
    public GameObject dim2Object;

    //the offsets for the objects    MAY NEED A SWITCH STATEMENT FOR THE DIFFERENT SETS TO HAVE DIFF. OFFSETS!!!!!!

        //pos offsets
    public Vector3 dim1_PosOffset;
    public Vector3 dim2_PosOffset;

    //rotation offsets
    public Quaternion dim1_RotationOffset;
    public Quaternion dim2_RotationOffset;

    //scale offsets
    public Vector3 dim1_ScaleOffset;
    public Vector3 dim2_ScaleOffset;

    //this bool will state if the dim. 1 object or dim 2 object will be in view
    public bool Dim1InView;

    
  
    

	void Start () {

        //we want the second dim. objects to be in the current dim initially
        //Dim1InView = false;
        //sets the objects to be invis
        dim1Object.SetActive(false);
        //dim2Object.SetActive(false);

        

	}

    
	
	// Update is called once per frame
	void Update () {

        //if dim 2 object is sapposed to be in view 
        if (Dim1InView == false)
        {
            dim1Object.SetActive(false);
            dim2Object.transform.position = this.transform.position + dim2_PosOffset;
            dim2Object.transform.rotation = dim2_RotationOffset;
            dim2Object.transform.localScale += dim2_ScaleOffset;
            dim2Object.SetActive(true);
        }
        else if (Dim1InView == true){
            dim2Object.SetActive(false);
            dim1Object.transform.position = this.transform.position + dim1_PosOffset;
            dim1Object.transform.rotation = dim1_RotationOffset;
            dim1Object.transform.localScale += dim1_ScaleOffset;
            dim1Object.SetActive(true);
        }

        
	
	}
}
