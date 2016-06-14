using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// different states and chapters for the game
/// </summary>

public class GameStates : MonoBehaviour {

    private int _currentScore;

    public static GameStates instance;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }



    public void AdjustScore(int num)
    {
        _currentScore += num;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 10, 10), "Score = " + _currentScore);
    }

    //different states of the game
    public GameObject GameStateObject;
    public Scene mainMenuScene = SceneManager.GetSceneByName("mainMenu");
    public Scene finalProjectScene = SceneManager.GetSceneByName("FinalProject");
    
   public enum States {MAIN_MENU, PAUSE, PLAY, GAME_OVER, QUIT, LOGO };
    static public bool  haveLoadedMenu = false;
    static public bool haveLoadedPlay = false;

    //different chapters / checkpoints? when the player is either in play or pause
    public enum Chapters {CHAPTER_0, CHAPTER_1, CHAPTER_2, CHAPTER_3, CHAPTER_NULL};
   public  States states;
    public Chapters chapters;
    // Use this for initialization
  
    void Start () {
        //should change to team logo intro and then start main menu scene 
        if (SceneManager.GetActiveScene().name != "FinalProject")
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
                if (haveLoadedMenu == false)
                {
                    
                    SceneManager.LoadScene("mainMenu");
                 
                    haveLoadedMenu = true;
                }
               
            
                break;
            case States.PLAY:
                //if (SceneManager.GetActiveScene().name != "FinalProject")
                if (haveLoadedPlay == false)
                {
                    SceneManager.LoadScene("FinalProject");
                
                    Debug.Log("You have loaded in the final project scene");
                    haveLoadedPlay = true;
                }
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
       
        states = States.PLAY;
    }
}
