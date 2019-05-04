using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockingDoorController : MonoBehaviour
{
    private AudioSource knockingDoor;
    // Start is called before the first frame update
    void Start()
    {
        knockingDoor = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            knockingDoor.panStereo = -1; //Sound in the left ear
            knockingDoor.Play();

            Destroy(gameObject);
        }
    }
}
