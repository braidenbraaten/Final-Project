using UnityEngine;
using System.Collections;

/// <summary>
/// The lane class should:
/// []Rotation Wheel
/// []bool to check if when the keys are dropped, they are being dropped in the correct lane
/// []
/// </summary>

    //the Lane Class
public class ItemLanes : MonoBehaviour {
    public enum LANE {VOID_LEFT, ONE,TWO,THREE,FOUR, VOID_RIGHT};
    //the rotating wheel that holds the keys
    public Rotation_Wheel wheel;
    //use the keys to track where they are falling 
    public GameObject keys;
    //check to see if when the keys drop, if they are in the correct lane
    bool inCorrectLane = false;

    void Start()
    {
        
    }

    void Update() 
    {
        
    }
    

}
