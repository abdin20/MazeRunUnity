using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


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
