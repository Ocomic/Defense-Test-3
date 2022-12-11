using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void ModifyScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log("Your Score: " + score);
    }
 
    
}
