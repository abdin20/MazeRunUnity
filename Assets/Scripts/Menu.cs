using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    // method for when play button is pushed
    public void Play(){

        //load game scene when play is pressed
        SceneManager.LoadScene("Game");

    }

    //method for quit button
    public void Quit(){
        //quit the application
        Application.Quit();
    }
}
