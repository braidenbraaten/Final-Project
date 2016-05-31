using UnityEngine;
using System.Collections;
/// <summary>
/// This is the rotation wheel that will rotate the key object in either a circle motion or oval esc... 
/// </summary>
public class Rotation_Wheel : MonoBehaviour {
    public bool hasStarted;
    public GameObject Wheel;
    //the position on the wheel that we want to hold the keys
    public Transform Keypos;
    public float rotSpeed = 2f;
    void Start()
    {
        hasStarted = false;
    }

    void Update()
    {


    }

    //the function that will enact the first drop / first player interaction
    void FirstDrop()
    {

    }
    //if the player interacts for the first time the keys drop and the lights go out
    

    //have a function for when the keys drop to cause the lights to go out and come back on 
    //and have the keys position reset before they come back on (so it looks like they 
    //just reappeared there).


}
