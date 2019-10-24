using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.1f;
    private Vector3 velocity = Vector3.zero;

    public float yOffset;
    public float xOffset;
    public float zOffset;

    void Start()
    {
        Vector3 initPosition = target.transform.position;
        initPosition.y += yOffset;
        transform.position = initPosition;
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothing);
    }
}
