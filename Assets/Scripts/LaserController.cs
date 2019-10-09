using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Based off "Fun With Lasers!" Tutorial from learn.unity.com by Mike Guy

public class LaserController : MonoBehaviour
{
    private LineRenderer line;

    public GameObject weaponModel;
    public float laserDistance = 100.0f;
    public Texture laserTexture;

    // Start is called before the first frame update
    void Start()
    {

        // Show the line and remove the cursor
        // Also set line to be a gameObject
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;

        // Remove the cursor
        Cursor.visible = false;

       
        // Define the colour of the laser
        Color c1 = new Color32(200, 50, 50, 128); 
        Color c2 = new Color32(200, 50, 50, 128);

        // Set the shader to be red
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = c1;
        line.endColor = c2;

    }

    // Update is called once per frame
    void Update()
    {
        // Set Shader

        // Sets the laser to be pointing in the direction of the weapon model
        Ray ray = new Ray(weaponModel.transform.position, weaponModel.transform.forward);
        RaycastHit hit;

        // Creates the laser so that it does not pass through anything 
        if (Physics.Raycast(ray, out hit, laserDistance))
        {
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, ray.GetPoint(laserDistance));
        }


        // Creates laser 
        // line.SetPosition(0, ray.origin);
        // line.SetPosition(1, ray.GetPoint(laserDistance));

    }
    

}
