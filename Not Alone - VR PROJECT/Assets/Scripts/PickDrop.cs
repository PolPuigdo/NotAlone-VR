using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickDrop : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;

    [HideInInspector]
    public Hand activeHand = null;

    public virtual void Light()
    {
        print("Light");
    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.Euler(-90, 180, 0);
        transform.localPosition = offset;
        transform.SetParent(null);
    }
}
