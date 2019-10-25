using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelection : MonoBehaviour
{
    public Button[] difficultyButtons;
    public Button[] locationButtons;


    // Start is called before the first frame update
    void Start()
    {
        // Set default difficulty to 0 or if user has their own preference
        int difficulty = LoadDifficulty();
        difficultyButtons[difficulty].interactable = false;

        // Set location based on user preference
        int location = LoadLocation();
        if (location != -1)
        {
            locationButtons[location].interactable = false;
        }
    }

    // Saves user location choice to player prefs
    public void SaveLocation()
    {
        for (int i = 0; i < locationButtons.Length; i++)
        {
            if (!locationButtons[i].IsInteractable())
            {   
                PlayerPrefs.SetInt("Location", i);
                return;
            }
        }
        // If nothing is selected, save location as -1 (random location)
        PlayerPrefs.SetInt("Location", -1);
    }

    // Loads the location that player selected
    public int LoadLocation()
    {
        if (PlayerPrefs.HasKey("Location"))
        {
            return PlayerPrefs.GetInt("Location");
        }
        return -1;
    }

    // Saves the difficulty 
    public void SaveDifficulty()
    { 
        for (int i = 0; i < difficultyButtons.Length; i++)
        {
            if (!difficultyButtons[i].IsInteractable())
            {
                PlayerPrefs.SetInt("Difficulty", i);
            }
        }
    }

    // Loads player last saved difficulty
    public int LoadDifficulty()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            return PlayerPrefs.GetInt("Difficulty");
        }

        return 0;
    }
}
