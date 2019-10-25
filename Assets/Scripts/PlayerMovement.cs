using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 10.0f;
    //public Transform target;
    public GameObject player;
    public float sensitivity;

    private float xLoc;
    private float zLoc;
    private float yLoc;

    //private bool inObj;

    // Start is called before the first frame update
    void Start()
    {
        // Initalise the player looking foward
        player.transform.LookAt(transform.forward);
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


        // Adapted from Lab 8 solutions but is being utilised to control the direction of a character
        Vector2 mouseScreenPos = Input.mousePosition;


        //  game world plane is. Since it's played in the X-Z plane (Y = 0)
        // we can simply take the camera's y-position to be this distance.
        float distanceFromCameraToXZPlane = Camera.main.transform.position.y;

        // Next we can use the camera method ScreenToWorldPoint(). Note that this
        // method expects a Vector3 (not a Vector2), where x and y are the
        // screen pixel coordinates, and z is the world distance from the camera 
        // to project to.
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        Vector3 facepos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);

        // Set the player to look at the point of intercetion
        player.transform.LookAt(new Vector4(facepos.x, player.transform.forward.y, facepos.z));
        
    }

}