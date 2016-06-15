using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// different states and chapters for the game
/// </summary>

public class GameStates : MonoBehaviour {
    private static GameStates instance = null;
    private bool goneToMenu = false;
    private bool goneToPlay = false;
    public static GameStates GetInstance()
    {
        if (instance == null)
        {
            instance = new GameStates();
        }
        return instance;
    }




    void setMenu()
    {
        Debug.Log("Going to Menu");
        if (goneToMenu == false && SceneManager.GetActiveScene() != SceneManager.GetSceneAt(0))
        {
            SceneManager.LoadScene(0);
            goneToMenu = true;
        }
    }

    void setPlay()
    {
        Debug.Log("Going to play");
        if (goneToPlay == false)
        {
            SceneManager.LoadScene(1);
            goneToPlay = true;
        }
    }

}
