using UnityEngine;
using UnityEngine.Events;
using System.Collections;

/*
Program adapted from "HealthManager" Lab8 Solutions for COMP30019 By The 
University Of Melbourne School Of Computing And Information Systems
*/

// Note this is for the enemy not the hero

public class HealthAndScoreManager : MonoBehaviour
{

    //public ScoreManager scoreManager;
    public int startingHealth = 100;
    public ParticleSystem explosion;
    //public int enemyScoreValue = 10;

    // Use Unity's event system to decouple logic relating
    // to "dying" from managing health. This is good practice
    // for writing extensible code.
    //public UnityEvent zeroHealthEvent;

    private int currentHealth;

    // Use this for initialization
    void Start()
    {
        this.ResetHealthToStarting();
    }

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health lte zero, destroy the object
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {

            // Destroy the enemy and incriment the score when enemy is destroyed
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            explosion.Play();

            // Find the score manager GameObject
            //this.scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

            // Incriment Score 
            ///scoreManager.score = scoreManager.score + enemyScoreValue;

            //this.zeroHealthEvent.Invoke();

        }
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }
}
