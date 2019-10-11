using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    //the player oject that the camera will follow
    public GameObject gameobject;

    //position of the camera w.r.t the player
    public Vector3 _offset= new Vector3(0f, 24f, -5f);

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - gameobject.transform.position;
    }

    void LateUpdate()
    {
        //taken from lab02 camera.
        Vector3 lookVec = gameobject.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(lookVec, Vector3.up);


        Vector3 pos = gameobject.transform.position + _offset;
        transform.position = Vector3.Slerp(transform.position, pos, 1.0f);
        //transform.LookAt(gameObject.transform);
    }
}
