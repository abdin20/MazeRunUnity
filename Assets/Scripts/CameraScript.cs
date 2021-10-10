using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{   
    public float timeElapsed;
    public float startTime; 

    public Vector3 playerDistance;

    public GameObject player;

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;

        playerDistance=(this.transform.position-player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed= Time.time-startTime;
        text.GetComponent<TMP_Text>().text="Time: "+ timeElapsed.ToString();
        GlobalScore.currentScore= Mathf.RoundToInt(Mathf.Sqrt(timeElapsed)*50f);    

        this.transform.position=player.transform.position+playerDistance;

    }
}
