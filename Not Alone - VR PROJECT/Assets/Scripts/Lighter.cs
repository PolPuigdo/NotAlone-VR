using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject flame;
    public GameObject lightFlame;
    public Vector3 offset = Vector3.zero;
    public bool isOn = false;
    private AudioSource lighterOnSound;

    [HideInInspector]
    public Hand activeHand = null;

    // Start is called before the first frame update
    void Start()
    {
        lighterOnSound = GetComponent<AudioSource>();
        lightOff();
    }


    public void lighterAction()
    {
        if (isOn)
        {
            lightOff();
        } else
        {
            lightUp();
        }
    }

    private void lightUp()
    {
        isOn = true;

        lighterOnSound.Play();
        
        flame.SetActive(true);
        lightFlame.SetActive(true);
    }

    private void lightOff()
    {
        isOn = false;

        flame.SetActive(false);
        lightFlame.SetActive(false);
    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.Euler(0, 180, 0); //Changing the angle
        transform.localPosition = offset;
        //transform.SetParent(null);
    }

    public void CancelOffset()
    {
        transform.SetParent(null);
    }
}
