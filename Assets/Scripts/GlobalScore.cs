using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GlobalScore
{
    public static List<Score> scoreList =new List<Score>();
    public static int currentScore {get; set; }


    public static bool canSubmit=false;

    public static bool didWin=false;

}