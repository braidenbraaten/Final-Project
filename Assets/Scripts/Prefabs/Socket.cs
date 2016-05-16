using UnityEngine;
using System.Collections;

public class Socket : MonoBehaviour {
    
    
    
    public Transform SocketPosition;
  

	// Use this for initialization
	void Start () {
       
        this.transform.position = SocketPosition.position;
        

	}
	
	// Update is called once per frame
	void Update () {

       

        //thisSet.transform.position = SocketPosition.position;

	}

    
}
