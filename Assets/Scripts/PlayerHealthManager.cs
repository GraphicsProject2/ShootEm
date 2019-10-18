using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

    public Text healthDisplay;
    public int healthLoss;
    public int playerHealth;
    public string enemyName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Display health 
        this.healthDisplay.text = "Health: " + playerHealth;

        // Exit the scene when health reaches  0
        
    }

    void OnTriggerEnter(Collider col)
    {
        // Checks if it is an enemy prefab
        if(col.gameObject.name == enemyName)
        {
            // Decrement health if so 
            Destroy(col.gameObject);
            playerHealth = playerHealth - healthLoss;
        }
        Debug.Log(playerHealth);

    }
}
