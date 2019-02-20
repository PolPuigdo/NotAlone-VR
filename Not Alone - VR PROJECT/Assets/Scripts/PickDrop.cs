using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickDrop : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public GameObject lightF; //Light for the flashlight
    private bool isOn = false; //Bool light on/off = true/false

    [HideInInspector]
    public Hand activeHand = null;

    public virtual void Light()
    {
        if (!isOn)
        {
            lightF.SetActive(true);
            isOn = true;
        } else
        {
            lightF.SetActive(false);
            isOn = false;
        }
    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.Euler(-90, 180, 0);
        transform.localPosition = offset;
        transform.SetParent(null);
    }
}
