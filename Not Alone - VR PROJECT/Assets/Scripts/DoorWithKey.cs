using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public Door door;
    public string keyName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == keyName)
        {
            door.openable = true;
            Destroy(collision.gameObject);
        }
    }
}
