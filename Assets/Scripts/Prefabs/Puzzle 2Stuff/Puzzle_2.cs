using UnityEngine;
using System.Collections;
/// <summary>
/// This Puzzle (2) will be the puzzle where the player will have to get the key from the beverage cooler, they will have to get the keys to drop from the rotating chain
/// the first time the player trys to use it it will be stuck and the part will fall to the void (dark area that the player canno't see), the lights will flicker, and then the keys will 
/// re-appear. The goal is to try and get the keys to fall down the correct lane when the player goes to open the door (the thing that activates the drop of the keys) .
///  
/// Maybe make it a little more difficult for the player for each time that the door will be opened ?
/// 
///               LIGHTING: needs to be in a runway fashion, aka... blinking lights moving towards the player, indicating the direction of the keys when they fall 
/// </summary>
public class Puzzle_2 : MonoBehaviour {
    //bool for checking if the start / first door opening has happened 
    public bool hasStarted;

    //runway lights in the lane of the beverage cooler
    public Light[] runway_Lights;

    //the Key game object
    public GameObject key;

    //different Lanes within the cooler (remember, only 1 lane is the correct lane!) the 5th lane is the void behind the lanes (if they drop it while the keys arent facing any of the lanes
    private int[] Lanes = new int[5];


	// Use this for initialization
	void Start () {
        hasStarted = false;

	}
	
	// Update is called once per frame
	void Update () {
      
	
	}

    public int GetLanes(int i)
    {
        
        return Lanes[i];
    }
}
