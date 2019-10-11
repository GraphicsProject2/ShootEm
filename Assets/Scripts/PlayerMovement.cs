using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 10.0f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player position
        Vector3 position = transform.position;

        if (Input.GetKey("w"))
        {
            position.z += movespeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            position.z -= movespeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            position.x -= movespeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            position.x += movespeed * Time.deltaTime;
        }

        transform.position = position;

        // Player rotation
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition.y = 1;
        //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector3 relativePosition = targetPosition - mousePosition;

        //Quaternion rotation = Quaternion.LookRotation(relativePosition);
        //transform.rotation = rotation;

        transform.LookAt(Input.mousePosition);
    }
}
