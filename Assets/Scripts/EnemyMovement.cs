using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public Rigidbody enemy;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        Vector3 movement = new Vector3();
        // Player position
        //Vector3 position = transform.position;

        movement = transform.forward * moveSpeed;

        enemy.velocity = movement;
    }
}
