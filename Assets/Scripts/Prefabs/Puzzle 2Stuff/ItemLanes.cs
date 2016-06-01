using UnityEngine;
using System.Collections;


public class ItemLanes : MonoBehaviour {
    public GameObject Keys;
    private float x; //used for the x value between -1 and 1 to determine which lane thee keys will fall into
    public enum LANE {VOID_LEFT, ONE,TWO,THREE,FOUR, VOID_RIGHT};
    public LANE lane;
	// Use this for initialization
	void Start () {
        

    }
	
	
	// Update is called once per frame
	void Update () {
        x = Keys.transform.position.x;
	
	}

    void CheckLanes(float currPos)
    {
        if (currPos < (-2f / 3f)) //void Left
        {
            lane = LANE.VOID_LEFT;
        }
        else if ((-2f / 3f) <= x && x < (-1f / 3f)) //Lane 1
        {
            lane = LANE.ONE;
        }
        else if ((-1f / 3f) <= x && x < 0) // Lane 2
        {
            lane = LANE.TWO;
        }
        else if (0 <= x && x < (1f / 3f)) // Lane 3
        {
            lane = LANE.THREE;
        }
        else if ((1f / 3f) <= x && x < (2f / 3f))// Lane 4
        {
            lane = LANE.FOUR;
        }
        else if (x >= (2f / 3f))
        {
            lane = LANE.VOID_RIGHT; // Void Right
        }


    }
}
