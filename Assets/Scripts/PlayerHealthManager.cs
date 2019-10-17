using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

    public Text healthDisplay;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Set the players health by default
        playerHealth = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Display health 
        this.healthDisplay.text = "Health: " + playerHealth;
    }
}
