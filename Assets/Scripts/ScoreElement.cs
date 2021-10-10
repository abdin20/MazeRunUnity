using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    public int score;

    GameObject playerNameObject;
    GameObject playerScoreObject;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setScore(string name, int score){
        this.name=name;
        this.score=score;

        //set name and score 
        playerNameObject = this.gameObject.transform.GetChild (0).gameObject;
        playerScoreObject= this.gameObject.transform.GetChild (1).gameObject;

        //get text mesh component to change score
        playerNameObject.GetComponent<TMP_Text>().text=name;
        playerScoreObject.GetComponent<TMP_Text>().text=score.ToString();
    }

    //getters for score and name
    public string getScore(){
        return score.ToString();
    }
       public string getName(){
        return name;
    }
}
