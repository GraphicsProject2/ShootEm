using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Starts the game
    public void StartGame()
    {
        // If game is paused, start it
        if (Time.timeScale != 1f)
		{
			Time.timeScale = 1f;
		}

        // Loads the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the game
    public void QuitGame()
    { 
        //Debug.Log("Game Exited");
        Application.Quit();
    }
}
