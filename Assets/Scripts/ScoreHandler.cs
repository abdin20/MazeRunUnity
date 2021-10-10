using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using Random=UnityEngine.Random;


public class ScoreHandler : MonoBehaviour
{

    //list of highscores
    public List<Score> scoreList;
    [SerializeField] int maxScores = 5;

    //to create a gameobject for the actual score to display
    public GameObject scoreElementPrefab;

    //submit names
    public string username;

    //current score that player has to submit
    public int currentScore;

    //setter for username
    public void setUsername(string name){
        this.username=name;
    }

    public void addScore()
    {

        
        scoreList.Add(new Score(this.username,  Random.Range(1, 4000)));
         updateScoreUI();
    }

    void Start()
    {   


        maxScores = 6;
        scoreList = new List<Score>();

        var scoreObject = Instantiate(scoreElementPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        scoreObject.transform.SetParent(this.gameObject.transform);
        //add to list of scores
        scoreList.Add(new Score("nam", 1));
        scoreObject.transform.GetComponent<ScoreElement>().setScore("nam", 1);

        scoreObject = Instantiate(scoreElementPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        scoreObject.transform.SetParent(this.gameObject.transform);
        //add to list of scores
        scoreList.Add(new Score("test", 34343434));
        scoreObject.transform.GetComponent<ScoreElement>().setScore("test", 34343434);


        // var firstTextObject = scoreObject.transform.GetChild(0).gameObject;

        // firstTextObject.GetComponent<TMP_Text>().text="HELLO";
        // textObject.GetComponent<TextMeshPro>().text = "HELLO";
        // scoreObject.transform.Find("PlayerNameText").text="HELLO";
        // scoreObject.transform.Find("ScoreText").text="123";



        updateScoreUI();



        // scoreList.add(new ScoreElement(ScoreElementPrefab));
        currentScore = 100;
    }

    //method to update scoreui once new data is found
    void updateScoreUI()
    {   

        var counter=0;

        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        //reorder scorelist by score
        scoreList = scoreList.OrderByDescending(x => x.score).ToList();

        //go thru each score and instantiate them
        foreach (Score score in scoreList)
        {     
            counter++;
            //only print up to n amount of scores
            if (counter>maxScores){
                break;
            }
            //create gameojbect
            var scoreObject = Instantiate(scoreElementPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //set parent for proper positioning
            scoreObject.transform.SetParent(this.gameObject.transform);
            //set information of score to ui
            scoreObject.transform.GetComponent<ScoreElement>().setScore(score.name, score.score);

        }
    }
}
