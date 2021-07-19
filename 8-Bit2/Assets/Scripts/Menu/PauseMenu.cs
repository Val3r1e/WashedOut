using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenu1;

    // Update is called once per frame
    void Update()
    {
        //If esc is pressed
        if(Input.GetKeyDown(KeyCode.Escape)){

            //If game is already paused
            if(isPaused){

                //Resume with the game
                Resume();
            }
            //Else if game isn't paused yet
            else{

                //Pause game 
                Pause();
            }
        }
    }

    //Used by ResumeButton and esc
    public void Resume(){

        //Activate pause menu
        pauseMenu1.SetActive(false);

        //Set time to 1
        Time.timeScale = 1.0f;

        //Unfreeze player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = false;

        //IsPaused is now true
        isPaused = false;
    }

    //Used by esc
    void Pause(){

        //Activate pause menu
        pauseMenu1.SetActive(true);

        //Set time to 0, can also be used for slowmotion 
        Time.timeScale = 0.0f;

        //Freeze player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;

        //IsPaused is now true
        isPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame(){
        Debug.Log ("QUIT");
    	Application.Quit();
    }
}
