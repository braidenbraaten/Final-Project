using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//This object should hold object 1 as the first dim object, and the second as the second dim object


public class ObjectSwitchTemplate : MonoBehaviour {
    //do you want rng or just two set objects everytime?
    public bool rngMode;
    // Use this for initialization
    public GameObject Object1;
    public GameObject Object2;
    public bool ob1;
    public bool ob2;
    //the items that are from the First dimension
    public List<GameObject> Dimension_one_Items;
    //Items that are from the Second dimension
    public List<GameObject> Dimension_two_Items;
    int rngDim1;
    int rngDim2;
    

	void Start () {

        ob1 = false;
        ob2 = false;
        Object1.SetActive(false);
        Object2.SetActive(false);
        //sets the rng range to the amount of items in each dim
        rngDim1 = Random.Range(0, Dimension_one_Items.Count);
        rngDim2 = Random.Range(0,Dimension_two_Items.Count);
        
      
	}

    // When it comes to the lists that we need for the dim objects, we are going to need a tag for each item so we can identify it and place it in the correct spot;
	
	// Update is called once per frame
	void Update () {
        if (ob1 == true && ob2 == false)
        {
            Object1.SetActive(true);
            //ob1Pos.transform.position = this.transform.position;
            Object1.transform.position = this.transform.position;
            Object2.SetActive(false);
        }

        if (ob2 == true && ob1 == false)
        {
            Object2.SetActive(true);
            Object2.transform.position = this.transform.position;
            Object1.SetActive(false);
        }

        if (ob1 == true && ob2 == true)
        {
            Object1.SetActive(false);
            Object2.SetActive(false);
        }

        if (ob1 == false)
        {
            Object1.SetActive(false);
        
        }

        if (ob2 == false)
        {
            Object2.SetActive(false);
        }
        
        
	
	}
}
