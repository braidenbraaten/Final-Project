using UnityEngine;
using System.Collections;

public class HoverOver : MonoBehaviour {
    //the hovering object
    public GameObject hoverItem;
    //Notification location
    public GameObject notifLoc;
    Quaternion notifRot;
    public float HeightFromObject;
    public float rotSpeed;
    float rot;
    Vector3 hover;
    //is Hovering in an upwards direction?
    bool hovUp;


    public float HoverHeightMin;
    public float HoverHeightMax;
    public float HoverSpeed;


	// Use this for initialization
	void Start () {
        hoverItem.transform.position = notifLoc.transform.position + new Vector3(0,HeightFromObject,0);
        hovUp = false;
        hover.y += .1f;
	}
	
	// Update is called once per frame
	void Update () {
        
        

        if(hover.y > HoverHeightMax)
        {
            hover.y = HoverHeightMax;
            hovUp = false;
            
        }

        if (hover.y < HoverHeightMin)
        {
            hover.y = HoverHeightMin;
            hovUp = true;
            
        }

        if (hovUp)
        {
            hover.y += HoverSpeed;
        }
        else if (!hovUp)
        {
            hover.y -= HoverSpeed;
        }

        rot += rotSpeed * Time.deltaTime;
        hoverItem.GetComponentInParent<Transform>().rotation = Quaternion.Euler(new Vector3(0, rot += rotSpeed, 0));

        hoverItem.GetComponent<Transform>().position = hover;

        


       
       
	}


    

    
}
