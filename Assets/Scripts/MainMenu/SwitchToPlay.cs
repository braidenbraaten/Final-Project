using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SwitchToPlay : MonoBehaviour {
    public bool hasSwitched;
    public GameStates gameState;
    // Use this for initialization



    void Update()
    {
        if (hasSwitched)
        {
            
           
            DestroyObject(gameState);
            hasSwitched = false;
        }
    }

    public void Switch()
    {
        hasSwitched = true;
        
    }
}
