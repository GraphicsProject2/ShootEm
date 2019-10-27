using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 10.0f;
    //public Transform target;
    //public GameObject player;
    public float sensitivity;
    Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        // Initalise the player looking foward
        //player.transform.LookAt(transform.forward);
        player = GetComponent<Rigidbody>();
        player.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		//this.GetComponent<Actions>().Aiming();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        //// Player position
        ////Vector3 position = transform.position;


        //if (Input.GetKey("w"))
        //{
        //    movement.z += movespeed;
        //}
        //if (Input.GetKey("s"))
        //{
        //    movement.z -= movespeed;
        //}
        //if (Input.GetKey("a"))
        //{
        //    movement.x -= movespeed;
        //}
        //if (Input.GetKey("d"))
        //{
        //    movement.x += movespeed;
        //}

        //player.velocity += movement;

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

        /*
        // Player direction
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition.y = 1
        // Use sensitivity inorder to change the rate the weapon moves
        ///xLoc = sensitivity * (mousePosition.x - (Screen.width - (Screen.width / 2)));
        / zLoc = sensitivity * (mousePosition.z - (Screen.height - (Screen.height / 2
        // Set the weapon to be faceing foward
        //player.transform.rotation.eulerAngles
        //Debug.Log(new Vector3(xLoc, this.transform.forward.y, zLoc
       // player.transform.LookAt(new Vector3(xLoc, this.transform.forward.y , 
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 relativePosition = targetPosition - mousePosition;
        Debug.Log(mousePosition);
        Quaternion rotation = Quaternion.LookRotation(relativePosition);
        transform.rotation = rotation;
        */
        player.transform.eulerAngles = new Vector3(0f, player.transform.eulerAngles.y, player.transform.eulerAngles.z);


		// To keep the player within the boundaries
		if (player.transform.position.x > 250)
		{
			player.transform.position = new Vector3(250f, player.transform.position.y, player.transform.position.z);
		}
		if (player.transform.position.x < -250)
		{
			player.transform.position = new Vector3(-250f, player.transform.position.y, player.transform.position.z);
		}
		if (player.transform.position.z > 250)
		{
			player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 250f);
		}
		if (player.transform.position.z < -250)
		{
			player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -250f);
		}


	}

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        // Player position
        //Vector3 position = transform.position;


        if (Input.GetKey("w"))
        {
            movement.z += movespeed;
        }
        if (Input.GetKey("s"))
        {
            movement.z -= movespeed;
        }
        if (Input.GetKey("a"))
        {
            movement.x -= movespeed;
        }
        if (Input.GetKey("d"))
        {
            movement.x += movespeed;
        }

        player.velocity = movement;
        Debug.Log(player.position);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject==Resources.Load("ScifiCrate_2", typeof(GameObject)))
        {
            Destroy(gameObject);
        }
    }
}
