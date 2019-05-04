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
            StartCoroutine(playKnocking());

            
        }
    }

    private IEnumerator playKnocking()
    {
        knockingDoor.panStereo = -0.8f; //Sound in the left ear (80%)
        knockingDoor.Play();
        yield return new WaitForSeconds(knockingDoor.clip.length);

        Destroy(gameObject);
        yield return new WaitForSeconds(0);
    }
}
