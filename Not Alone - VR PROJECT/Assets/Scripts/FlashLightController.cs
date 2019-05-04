using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlashLightController : MonoBehaviour
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

    public virtual void changeLight() //Turns on/off the light
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

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.Euler(-90, 180, 0); //Changing the angle because it was vertically by default
        transform.localPosition = offset;
    }

    public void CancelOffset()
    {
        transform.SetParent(null);
    }
}
