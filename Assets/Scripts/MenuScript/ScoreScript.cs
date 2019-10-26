using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class displays the users high score */
public class ScoreScript : MonoBehaviour
{
	int highScore;
	public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // If player has a high score, score high score.
		if (PlayerPrefs.HasKey("Score"))
		{
			this.highScore = PlayerPrefs.GetInt("Score");
		}

        // Otherwise shows a 0
		else
		{
			this.highScore = 0;
		}


    // Display the score.
	this.highScoreText.text = "High Score: " + this.highScore;
	}
}
