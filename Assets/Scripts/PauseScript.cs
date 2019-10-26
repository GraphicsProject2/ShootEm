using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the even where user wants to pause the game */
public class PauseScript : MonoBehaviour
{
	public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If game is paused, unpause
            if (pauseMenu.activeSelf)
			{
				// resume the game
				Time.timeScale = 1f;
				pauseMenu.SetActive(false);
			}

            // Otherwise pause it
            else
			{
				// Pause the game
				Time.timeScale = 0;
				pauseMenu.SetActive(true);
			}
			
        }
    }
}
