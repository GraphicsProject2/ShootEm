using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
Program adapted from "ProjectileController" Lab8 Solutions for COMP30019 By The 
University Of Melbourne School Of Computing And Information Systems
*/


public class BulletController : MonoBehaviour
{

    private Vector3 initialPos;
    

    // Settings for the bullet that will determine its features 
    public float range;
    public float speed;
    public int damageAmount;

    private string enemyName = "Enemy2(Clone)";

    //public string tagToDamage;


    void Start()
    {
        // Record the inital location of the bullet inorder to calculate range 
        initialPos = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Move the object foward
        this.transform.Translate(Vector3.forward * speed);

        // Destroy the object if it has gone out of range 
        if(Vector3.Distance(initialPos,this.transform.position) > range)
        {
            Destroy(this.gameObject);
        }

    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == enemyName)
        {
            // Damage object with relevant tag
            HealthAndScoreManager healthAndScoreManager = col.gameObject.GetComponent<HealthAndScoreManager>();
            healthAndScoreManager.ApplyDamage(damageAmount);
            Destroy(this.gameObject);

        }

        //Otherwise just destroy the bullet
        //Destroy(this.gameObject);
        
       

        
        //Destroy(col.gameObject);
        //Destroy(this.gameObject);
        
        Debug.Log(col.gameObject.name);
    }
}
