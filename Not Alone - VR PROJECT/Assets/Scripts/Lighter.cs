using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject flame;
    public GameObject lightFlame;
    public Vector3 offset = Vector3.zero;
    private bool isOn = false;
    private AudioSource lighterOnSound;

    [HideInInspector]
    public Hand activeHand = null;

    // Start is called before the first frame update
    void Start()
    {
        lighterOnSound = GetComponent<AudioSource>();
        lightOff();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        lighterOnSound.Play();

        isOn = true;
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
        transform.localRotation = Quaternion.Euler(-90, 90, 0); //Changing the angle because it was vertically by default
        transform.localPosition = offset;
        transform.SetParent(null);
    }
}
