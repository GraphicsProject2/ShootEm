using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Program adapted from "IncrimentScoreOnDestroy" Lab8 Solutions for COMP30019 By The 
University Of Melbourne School Of Computing And Information Systems
*/

public class IncrimentScoreOnKill : MonoBehaviour
{
    public int incrementAmount;
    public ScoreManager scoreManager;

    void Start()
    {
        // Find score manager by tag, if not referenced already
        if (scoreManager == null)
        {
            this.scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }
    }

    // Increment player score when destroyed
    void OnDestroy()
    {
        this.scoreManager.score += this.incrementAmount;
    }
}
