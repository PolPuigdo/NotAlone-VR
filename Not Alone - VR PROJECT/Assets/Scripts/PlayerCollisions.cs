using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject camera;
    public Vector3 offset = Vector3.zero;

    private void Start()
    {
        //camera.transform.SetParent(transform);
        //camera.transform.parent = transform;
        //transform.localPosition = offset;
    }


    private void FixedUpdate()
    {
        //camera.transform.parent = transform;
        //camera.transform.SetParent(transform);
        //transform.position += new Vector3(camera.transform.position.x,  camera.transform.position.y);
    }
}
