using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.rotationZ += rotationSpeed * Time.deltaTime;
        this.rotationZ %= 360;
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationZ);
    }
}
