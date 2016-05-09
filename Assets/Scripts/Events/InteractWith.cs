using UnityEngine;
using System.Collections;

public class InteractWith : MonoBehaviour {
    //The overall interactible game object
    GameObject interactObject;
    //player game object 
    public GameObject PlayerObject;
    //Text object's text mesh data
    TextMesh displayText;
    Vector3 playerPos;
  
	// Use this for initialization
	void Start () {
        interactObject = this.gameObject;
        displayText = this.gameObject.GetComponent("TextMesh") as TextMesh;
        
        //interactObject.GetComponent<MeshRenderer>().enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        //the vec3 of the player's pos 
        playerPos = PlayerObject.transform.position;
        
        //sets the displayed text output
        displayText.text = "Key to Front Door";
        
        //Makes the text look and follow the player while staying stationary
        displayText.transform.LookAt(playerPos);
        displayText.transform.Rotate(Vector3.up, 180f);

        //displays the text on collision enter / stay
        
        
    }

   
}
