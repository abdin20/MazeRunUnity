using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.IO;
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
                GlobalScore.scoreList.Add(new Score(this.username, GlobalScore.currentScore));
                saveScores();
            }

            GlobalScore.canSubmit=false;
            updateScoreUI();

        }


    }

    //TODO SAVE SCORE TO TEXT FILE
    public void saveScores(){
        
        //loop thru all scores in list
        var stringbuilder="";

        for (int m=0;m<GlobalScore.scoreList.Count;m++){
            stringbuilder+= GlobalScore.scoreList[m].name + GlobalScore.scoreList[m].score+"\n";

        }

        //write scores to text file
        System.IO.File.WriteAllText (System.IO.Directory.GetCurrentDirectory() +"/scores.txt", stringbuilder);


    }


    //
    void Start()
    {

        
        //check if file exists and if we already have a list of global scores
        if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() +"/scores.txt") && GlobalScore.scoreList.Count==0)
        {       
            Debug.Log("doubling");
            //create streamReader to get scores from file
            var sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() +"/scores.txt");
            var fileContents = sr.ReadToEnd();
             sr.Close();

            //split text by new lines
            var lines = fileContents.Split("\n"[0]);

            var username="";
            var score=0;

            //if at least 1 score exists must parse 
            if(lines.Length>0){
                Debug.Log(lines.Length);
                for(int m=0;m<lines.Length-1;m++){
                    Debug.Log(lines[m]);
                    //get username and score from line
                    username=(lines[m].Substring(0,3));
                    score=Int32.Parse(lines[m].Substring(3));

                        //add score to global list
                    GlobalScore.scoreList.Add(new Score(username, score));
                }
            }
        }  




        //can only submit score when player finishes level
        canSubmit = GlobalScore.canSubmit;
        
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

        //get rid of all old scores
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        //reorder scorelist by score
        GlobalScore.scoreList = GlobalScore.scoreList.OrderBy(x => x.score).ToList();

        //go thru each new score and instantiate them
        foreach (Score score in GlobalScore.scoreList)
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
