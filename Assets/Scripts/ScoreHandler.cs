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

    public bool canSubmit;



    //list of highscores
    public List<Score> scoreList;

    //reference to ui elements 
    public GameObject usernameCheck;
    public GameObject scoreText;
    public GameObject submitButton;
    public GameObject usernameInput;

    //max amount of highscores
    [SerializeField] int maxScores;

    //to create a gameobject for the actual score to display
    public GameObject scoreElementPrefab;

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
          
        //check if player can submit
        if (GlobalScore.canSubmit)
        {
            scoreList = GlobalScore.scoreList;
            //check for 3 letter username
            if (this.username.Length != 3)
            {
                usernameCheck.SetActive(true);
                return;
            }
            else
            {
                usernameCheck.SetActive(false);
                //if username good we add it to list
                scoreList.Add(new Score(this.username, GlobalScore.currentScore));
            }

            GlobalScore.canSubmit=false;
            updateScoreUI();

        }


    }
    //
    void Start()
    {

        //can only submit score when player finishes level
        canSubmit = GlobalScore.canSubmit;
        scoreList = GlobalScore.scoreList;
        maxScores = 6;
        currentScore = 0;

        updateScoreUI();
    }

    //method to update scoreui once new data is found
    void updateScoreUI()
    {

        //check if player is in state to submit score
        if(GlobalScore.canSubmit){
            scoreText.SetActive(true);
            submitButton.SetActive(true);
            usernameInput.SetActive(true);
        }else{
            scoreText.SetActive(false);
            submitButton.SetActive(false);
             usernameInput.SetActive(false);
        }

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
