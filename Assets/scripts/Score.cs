using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: MonoBehaviour
{
    public double score = 0;
    public double health = 5;

    public void AddScore()
    {
        score = score + 0.5;
    }

    public void ReduceHealth()
    {
        health -= 0.25;
    }

    public double GetScore()
    {
        return score;
    }

    public double GetHealth()
    {
        return health;
    }
}