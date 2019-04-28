using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public VaseEnigmaController controller;
    private AudioSource breakingAudio;

    // Start is called before the first frame update
    void Start()
    {
        breakingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hammer")
        {
            breakingAudio.Play();
            controller.breakVase();
        }
    }
}
