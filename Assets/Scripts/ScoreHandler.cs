using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using Random = UnityEngine.Random;


public class ScoreHandler : MonoBehaviour
{


    //list of highscores
    public List<Score> scoreList;

    public GameObject usernameCheck;

    //max amount of highscores
    [SerializeField] int maxScores;

    //to create a gameobject for the actual score to display
    public GameObject scoreElementPrefab;

    //submit names
    public string username;

    //current score that player has to submit
    public int currentScore;

    //setter for username
    public void setUsername(string name)
    {
        this.username = name;
    }

    public void addScore()
    {   
         scoreList= GlobalScore.scoreList;
        //check for 3 letter username
        if (this.username.Length != 3)
        {
            usernameCheck.SetActive(true);
        }
        else
        {
            usernameCheck.SetActive(false);
            //if username good we add it to list
            scoreList.Add(new Score(this.username, Random.Range(1, 100)));
            updateScoreUI();
        }


    }
//
    void Start()
    {

        scoreList= GlobalScore.scoreList;
        maxScores = 6;
        currentScore = 0;

        updateScoreUI();
    }

    //method to update scoreui once new data is found
    void updateScoreUI()
    {

        var counter = 0;

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
            if (counter > maxScores)
            {
                break;
            }


            //only if score was greater than 0
            if (score.score != 0)
            {
                var scoreObject = Instantiate(scoreElementPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                //set parent for proper positioning
                scoreObject.transform.SetParent(this.gameObject.transform);
                //set information of score to ui
                scoreObject.transform.GetComponent<ScoreElement>().setScore(score.name, score.score);
            }


        }
    }
}
