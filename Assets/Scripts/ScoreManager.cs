using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System;

/*
Program adapted from "ScoreManager" Lab8 Solutions for COMP30019 By The 
University Of Melbourne School Of Computing And Information Systems
*/
public class ScoreManager : MonoBehaviour
{
    public Text scoreDisplay;
    public int score = 0;

    public void ResetScore()
    {
        this.score = 0;
    }

    public void Update()
    {
        // Display the score
        this.scoreDisplay.text = "Score: " + this.score;
    }

    public void saveScore()
	{
		if (PlayerPrefs.HasKey("Score"))
		{
			if (this.score > PlayerPrefs.GetInt("Score"))
			{
				PlayerPrefs.SetInt("Score", score);
			}
		}
        else
		{
			PlayerPrefs.SetInt("Score", score);
		}
	}

    internal void bonusScore()
    {
        this.score += 200;
    }
}
