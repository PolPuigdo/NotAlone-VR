using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUpAble : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;

    [HideInInspector]
    public Hand activeHand = null;


    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.Euler(-90, 90, 0); //Changing the angle because it was vertically by default
        transform.localPosition = offset;
    }

    public void CancelOffset()
    {
        transform.SetParent(null);
    }
}
