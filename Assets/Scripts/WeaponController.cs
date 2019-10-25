using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * WeaponController is the primary script that the movement and operation of 
 * the players weapon is sourced from as well as displaying the information
 * attributed to the weapon on the screen.
 */



public class WeaponController : MonoBehaviour
{
    // Public objects to be assigned for each weapon
    public BulletController bulletPrefab;
    public Text ammoDisplay;
    public Text reloadDisplay;
    public GameObject player;

    // Public sounds to be used in the game
    public AudioSource shootSound;
    public AudioSource casingSound1;
    public AudioSource casingSound2;
    public AudioSource reloadSound;
    
    // Public variables to change the charactaristics and position of 
    // each weapon
    public int ammoCapacity;
    public float fireSpeed;
    public float reloadSpeed;
    public float accuracy;
    public float playerRight;
    public float playerFoward;

    // Private variables used within this function
    private int ammunition;
    private float timeSinceLastReload;
    private float timeSinceLastShot;
    private float shotError;
    private float shotErrorCoefficient = 2.0f;
    private float shotErrorMax = 5.0f;
    private bool shooting;
    private float newXRot;
    private float newYRot;
    private float newZRot;



    // Start is called before the first frame update
    void Start()
    {
        // Set ammunition
        ammunition = ammoCapacity;
        shotError = 0.0f;
        shooting = false;

        // Set all the sounds to be utilised within this function

    }

    // Update is called once per frame
    void Update()
    {

        //////////////////////////// Movement And Direction ////////////////////////////

        // Handle the position of the weapon relative to the player 
        this.transform.position = player.transform.position + (player.transform.forward * playerFoward)
            + (player.transform.right * playerRight);

        // Handle the direction the weapon is faceing (Sorced from PlayerMovement)
        // Adapted from Lab 8 solutions but is being utilised to control the direction of a character
        Vector2 mouseScreenPos = Input.mousePosition;

        // Take the distance from the camera
        float distanceFromCameraToXZPlane = Camera.main.transform.position.y;

        // Apply it to the screen
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);

        // Find the final facing position
        Vector3 facepos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);

        // Set the player to look at the point of intercetion
        this.transform.LookAt(new Vector4(facepos.x, player.transform.forward.y, facepos.z));


        //////////////////////////// Weapon Mechanics  ///////////////////////////////////

        // Reload the weapon

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the ammunition count
            ammunition = ammoCapacity;
            timeSinceLastReload = 0;

            // Play reload sound
            reloadSound.Play();

        }

        // Deturmine if the mouse key is being held down
        if(Input.GetMouseButtonDown(0) == true)
        {
            shooting = true;
        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            shooting = false;
        }

        // Fire the shot provided there is ammo and it doesnt exceed the fire rate 
        // and the hero hasnt reloaded recently
        if (shooting && (ammunition > 0) && 
            (timeSinceLastShot >= fireSpeed) && (timeSinceLastReload > reloadSpeed))
        {
            // Make a bullet and set its direction
            BulletController b = Instantiate<BulletController>(bulletPrefab);
            b.transform.position = this.transform.position;
            b.transform.rotation = this.transform.rotation;
            b.transform.LookAt(this.transform.position + this.transform.forward);

            // Adjust the rotation by the errorMargin
            newXRot = b.transform.rotation.x + (Random.Range(-shotError,shotError) * shotErrorCoefficient);
            newYRot = b.transform.rotation.y + (Random.Range(-shotError, shotError) * shotErrorCoefficient);
            newZRot = b.transform.rotation.z + (Random.Range(-shotError, shotError) * shotErrorCoefficient);

            b.transform.Rotate(new Vector4(newXRot,newYRot,newZRot));

            // Incriment the shot error defined by the maximum error
            if (shotError < shotErrorMax)
            {
                shotError = shotError + accuracy;
            }

            // Decriment ammo count
            ammunition = ammunition - 1;

            // Reset timeSinceLastShot
            if(timeSinceLastShot >= fireSpeed)
            {
                timeSinceLastShot = 0.0f;
            }

            // Play the sound for the bullet shooting
            shootSound.Play();

            // Play the sound of a bullet dropping
            if (Random.Range(0.0f, 1.0f) > 0.5)
            {
                casingSound1.PlayDelayed(0.3f);
            }
            else
            {
                casingSound2.PlayDelayed(0.3f);
            }
            
        }

        // Incriment timers
        timeSinceLastReload = timeSinceLastReload + Time.deltaTime;
        timeSinceLastShot = timeSinceLastShot + Time.deltaTime;


        // Decriment the error 
        if (shotError > 0.0f)
        { 
            shotError = shotError - (Time.deltaTime * shotErrorCoefficient);
        }

        ////////////////////////////// UI ////////////////////////////////////////////////////

        // Show if the user is reloading or not
        if(timeSinceLastReload > reloadSpeed)
        {
            this.reloadDisplay.text = "";
        }
        else
        {
            this.reloadDisplay.text = "Reloading...";
        }

        // Update the live Score
        this.ammoDisplay.text = "Ammo: " + ammunition + "/" + ammoCapacity;
    }



}
