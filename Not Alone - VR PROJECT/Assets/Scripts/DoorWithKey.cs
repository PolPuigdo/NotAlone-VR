using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public Door door;

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Key")
        {
            door.openable = true;
            Destroy(collision.gameObject);
        }
    }
}
