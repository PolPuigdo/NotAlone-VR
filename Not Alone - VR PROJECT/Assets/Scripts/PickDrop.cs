using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickDrop : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public GameObject lightF; 
    private bool isOn = false; 


    [HideInInspector]
    public Hand activeHand = null;

    public void Start()
    {
        lightF.SetActive(false); //Sets the light off by default
    }

    public virtual void Light() //Turns on/off the light
    {
        if (!isOn)
        {
            lightF.SetActive(true); //ON
            isOn = true;
        } else
        {
            lightF.SetActive(false); //OFF
            isOn = false;
        }

        GetComponent<AudioSource>().Play(); //Button sound
    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.Euler(-90, 180, 0); //Changing the angle because it was vertically by default
        transform.localPosition = offset;
        transform.SetParent(null);
    }
}
