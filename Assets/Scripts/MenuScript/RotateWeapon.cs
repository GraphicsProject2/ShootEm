using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class rotates the weapon about the z axis when selecting weapons */
public class RotateWeapon : MonoBehaviour
{
    public float rotationSpeed;
    private float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        this.rotationZ = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the weapon
        this.rotationZ += rotationSpeed * Time.deltaTime;
        this.rotationZ %= 360;
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationZ);
    }
}
