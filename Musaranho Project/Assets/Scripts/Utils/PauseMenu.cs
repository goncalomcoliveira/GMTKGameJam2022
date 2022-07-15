using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //value to check if game is paused or not
    public static bool gameIsPaused = false;

    //pause menu UI canvas to set active or inactive
    public GameObject pauseMenuUI;

    void Update(){
        //get pause key down
        if(Input.GetKeyDown(KeyCode.Escape)){
            //check to either pause or resume
            if(gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    //resume the game
    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    //pause the game
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
