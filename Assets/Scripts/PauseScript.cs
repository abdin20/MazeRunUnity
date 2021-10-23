using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{

    public GameObject canvas;
    public GameObject pauseMenu;
    public GameObject leaderMenu;

    void Start()
    {   
        //reset variables when camera starts 
        Time.timeScale=1f;
        GlobalScore.canSubmit=true;


        //get pause menu and leaderboard menu
        pauseMenu =GameObject.FindWithTag("pause");
        leaderMenu= GameObject.FindWithTag("leader");

        leaderMenu.SetActive(false);
        pauseMenu.SetActive(true);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if escape is pressed toggle between pause or not
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            togglePause();
        }

        //check if player won the game
        if(GlobalScore.didWin){ 
            //show leaderboard screen if so
            Time.timeScale=0f;
            canvas.SetActive(true);

            pauseMenu.SetActive(false);
            leaderMenu.SetActive(true);


        }

    }

    public void togglePause()
    {
        Debug.Log("toggling");
        //toggle between pausing and not
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
        }

    }

    public void Quit()
    {
        //quit the application
        Application.Quit();
    }

    //restart current scene
    public void Restart(){
        Application.LoadLevel(Application.loadedLevel);
            //player can submit scores if level restarted
            GlobalScore.canSubmit=true;
            GlobalScore.didWin=false;
    }

  public void Menu(){

        //load game scene when play is pressed
        SceneManager.LoadScene("MainMenu");
         
         //player cannot submit scores in main menu
         GlobalScore.canSubmit=false;
         //set winning flag to false 
         GlobalScore.didWin=false;

    }
}
