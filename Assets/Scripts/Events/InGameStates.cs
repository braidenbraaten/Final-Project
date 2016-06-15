using UnityEngine;
using System.Collections;

/// <summary>
/// Although there is a gamestate class, we will be using this class to act as a gamestate but for during the in game scene
/// not the main menu
/// </summary>

public class InGameStates : MonoBehaviour {
    //references to the puzzles
    public Puzzle_1 puz_1;
    public Puzzle_2 puz_2;
    static int CURR_ACT;
    public enum  ACTS { WAKE_UP, LOCK_DOOR, PUZZLE_1, PUZZLE_2, END };
    public       ACTS currentAct;


	// Use this for initialization
	void Start () {
        CURR_ACT = 0;
       
        currentAct = ACTS.WAKE_UP;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}



    //should switch between the acts that the player is going through
    void ChangeAct(ACTS curr)
    {
        switch (curr)
        {
            case ACTS.WAKE_UP:

                break;
            case ACTS.LOCK_DOOR:

                break;
            case ACTS.PUZZLE_1:

                break;
            case ACTS.PUZZLE_2:

                break;
            case ACTS.END:

                break;
        }

        Debug.Log("the current act is " + curr);
    }
}
