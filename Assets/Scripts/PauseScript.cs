using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{

    public GameObject canvas;

    void Start()
    {
        Time.timeScale=1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if escape is pressed toggle between pause or not
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            togglePause();
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
    }

  public void Menu(){

        //load game scene when play is pressed
        SceneManager.LoadScene("MainMenu");

    }
}
