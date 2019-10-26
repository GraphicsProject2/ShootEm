using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

    public void TryAgain()
	{
        // Restart the time
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
