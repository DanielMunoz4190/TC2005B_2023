using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: MonoBehaviour
{
    public int score = 0;
    public int health = 5;

    public void AddScore()
    {
        score += 1;
        print("Score: " + score);
    }

    public void ReduceHealth()
    {
        health -= 1;
        print("Health: " + health);
    }
}