using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrowController : MonoBehaviour
{
    public GameObject scarecrow;
    private AudioSource dramaHit;

    private void Start()
    {
        scarecrow.SetActive(false);
        dramaHit = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dramaHit.Play();
            scarecrow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(scarecrow);
            Destroy(gameObject);
        }
    }
}
