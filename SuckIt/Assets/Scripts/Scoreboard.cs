using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{ 
    // Text variables
    Text[] texts;              // List of texts in the Scoreboard prefab
    Text scorePoints;          
    Text healthPoints;         

    // Scoreboard dependand variables
    [SerializeField] public int health_Points = 100;
    [SerializeField] private int score_Points = 0;

    // Vacumm and DestroyCollided dependand variables
    [SerializeField] int score_Multiplier = 50;
    [SerializeField] int loseHealth_Multiplier = 10;

    public bool isAlive = true;

    // Start is called before the first frame update
    private void Awake()
    {
        texts = GetComponentsInChildren<Text>();
    }
    private void Start()
    {
        scorePoints = texts[0];
        healthPoints = texts[1];

        scorePoints.text = score_Points.ToString();
        healthPoints.text = health_Points.ToString();
    }

    public int GetScoreMultiplier()
    {
        return score_Multiplier;
    }
    public int GetLoseHealthMultiplier()
    {
        return loseHealth_Multiplier;
    }

    public void AddScore(int score)  
    {
        score_Points += score;
        scorePoints.text = score_Points.ToString();      
    }
    public void LoseHealth(int health)  
    {
        health_Points -= health;
        healthPoints.text = health_Points.ToString();
    }

    public void Die() { isAlive = false; }

}
