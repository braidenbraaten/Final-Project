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
    //we want the wheel, the door, the key, the lanes, and what to do with them
   
    public Rotation_Wheel wheel;
    public Door coolerDoor;
    public ItemLanes Lanes;

    //in order to know if the wheel is jammed or spinning
    public bool hasStarted = false;
    //determins if the key has been dropped or not
    public bool hasDropped = false;
    //audio clip for when the wheel is "Jammed"
    public AudioClip jammedSound;

    void Update()
    {
        //when the player opens the door, the keys will drop
        if (coolerDoor.open)
        {
            hasDropped = true;
        }



        if (hasStarted)
        {
            if (hasDropped)
            {
                
            }
        }
    }



}
