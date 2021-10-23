using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{   
    public float timeElapsed;
    public float startTime; 

    public Vector3 playerDistance;

    public GameObject player;

    public GameObject text;

    public bool lookAt=true;
    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;

        // playerDistance=(this.transform.position-player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed= Time.time-startTime;
        text.GetComponent<TMP_Text>().text="Time: "+ timeElapsed.ToString();

        //only keep updating score until player has won the game
        if(!GlobalScore.didWin){
             GlobalScore.currentScore= Mathf.RoundToInt(timeElapsed);    
        }
       
    }
}
