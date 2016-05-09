using UnityEngine;
using System.Collections;

public class InteractWith : MonoBehaviour {
    GameObject interactObject;
    public GameObject PlayerObject;
    TextMesh displayText;
	// Use this for initialization
	void Start () {
        interactObject = this.gameObject;
        displayText = this.gameObject.GetComponent("TextMesh") as TextMesh;
	}
	
	// Update is called once per frame
	void Update () {
        displayText.text = "Key to Front Door";
	
	}
}
