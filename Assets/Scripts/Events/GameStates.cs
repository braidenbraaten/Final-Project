using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour {
    //different states of the game
    enum States {MAIN_MENU, PAUSE, PLAY, GAME_OVER, QUIT };

    //different chapters / checkpoints? when the player is either in play or pause
    enum Chapters {CHAPTER_0, CHAPTER_1, CHAPTER_2, CHAPTER_3 };
    States states;
    Chapters chapters;
	// Use this for initialization
	void Start () {
        states = States.MAIN_MENU;
	}
	
	// Update is called once per frame
	void Update () {
        //switch between the different game states
        switch (states)
        {
            case States.MAIN_MENU:

                break;
            case States.PLAY:

                //if you are currently in play mode, check to see what chapter you are in
                switch (chapters)
                {
                    case Chapters.CHAPTER_0:

                        break;
                    case Chapters.CHAPTER_1:

                        break;
                    case Chapters.CHAPTER_2:

                        break;
                    case Chapters.CHAPTER_3:

                        break;
                }


                break;
            case States.PAUSE:

                break;
                //I don't know if we are going to have a game over state , its in here just in case (lol... case)
            case States.GAME_OVER:

                break;
            case States.QUIT:

                break;
        }
	
	}
}
