using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    public Button mainMenuButton;
    public Button tryAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenuHandler);
        tryAgainButton.onClick.AddListener(TryAgainHandler);
    }

    void MainMenuHandler()
    {
        SceneManager.LoadScene(0);

    }

    void TryAgainHandler()
    {
        SceneManager.LoadScene(1);
    }
}
