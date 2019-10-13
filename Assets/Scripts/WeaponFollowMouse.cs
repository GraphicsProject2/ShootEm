using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowMouse : MonoBehaviour
{
    public float sensitivity;
    public GameObject weapon;
    private float xLoc;
    private float yLoc;

    // Start is called before the first frame update
    void Start()
    {
        // Initalise the direction of the object (being foward)
        weapon.transform.LookAt(transform.forward);

    }

    // Update is called once per frame
    void Update()
    {
        // Find where the mouse is on the XZ plane 
        Vector2 mouseScreenPos = Input.mousePosition;

        // To fire a projectile towards the mouse position, we need to be able
        // to convert a 2D screen position into a world space position. In
        // order to do this we first have to figure out how far from the camera
        // the game world plane is. Since it's played in the X-Z plane (Y = 0)
        // we can simply take the camera's y-position to be this distance.
        //float distanceFromCameraToXZPlane = Camera.main.transform.position.y;

        // Next we can use the camera method ScreenToWorldPoint(). Note that this
        // method expects a Vector3 (not a Vector2), where x and y are the
        // screen pixel coordinates, and z is the world distance from the camera 
        // to project to.
        //Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);

        // Point the Current Weapon at the mouse

        // Generate the respective xy coordinates by taking the height and width of the screen
        // Inorder to get the center of the screen 

        // Use sensitivity inorder to change the rate the weapon moves
        xLoc = sensitivity * (mouseScreenPos.x - (Screen.width - (Screen.width / 2)));
        yLoc = sensitivity * (mouseScreenPos.y - (Screen.height - (Screen.height / 2)));

        // Set the weapon to be faceing foward
        weapon.transform.LookAt(new Vector3(xLoc,yLoc, 10.0f));
        Debug.Log(new Vector3(yLoc, xLoc, 10.0f));


    }
}
