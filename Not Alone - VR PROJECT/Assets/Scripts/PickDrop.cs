using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickDrop : MonoBehaviour
{
    [HideInInspector]
    public Hand activeHand = null;
}
