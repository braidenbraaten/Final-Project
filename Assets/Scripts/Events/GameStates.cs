using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// different states and chapters for the game
/// </summary>

public class GameStates : MonoBehaviour {
    //different states of the game
    enum States {MAIN_MENU, PAUSE, PLAY, GAME_OVER, QUIT, LOGO };

    //different chapters / checkpoints? when the player is either in play or pause
    enum Chapters {CHAPTER_0, CHAPTER_1, CHAPTER_2, CHAPTER_3, CHAPTER_NULL};
    States states;
    Chapters chapters;
	// Use this for initialization
	void Start () {
        //should change to team logo intro and then start main menu scene 
        states = States.MAIN_MENU;

        // the chapters should activate what puzzles are active within the scene, 0 = waking up and locking door, 1 = getting money from the till, 2 = getting the keys from the beverage cooler
        chapters = Chapters.CHAPTER_NULL;
	}
	
	// Update is called once per frame
	void Update () {
        //switch between the different game states
        switch (states)
        {
            case States.MAIN_MENU:
                if(SceneManager.GetActiveScene().name != "mainMenu")
                SceneManager.LoadScene("mainMenu");
            
                break;
            case States.PLAY:
                if (SceneManager.GetActiveScene().name != "FinalProject")
                    SceneManager.LoadScene("FinalProject");
                //if you are currently in play mode, check to see what chapter you are in
                switch (chapters)
                {
                    case Chapters.CHAPTER_0:
                        // lock the door scene 
                        break;
                    case Chapters.CHAPTER_1:
                        //should set puzzle 1 to active

                        break;
                    case Chapters.CHAPTER_2:

                        break;
                    case Chapters.CHAPTER_3:

                        break;
                    case Chapters.CHAPTER_NULL:

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

    void setPlay()
    {
        Debug.Log("Clicked Play");
        states = States.PLAY;
    }
}
