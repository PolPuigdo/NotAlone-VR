using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Door door;
    private AudioSource tensionSound;
    public AmbientalMusic musicController;
    public LightController lightController;

    // Start is called before the first frame update
    void Start()
    {
        tensionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            //Play sound
            tensionSound.Play();

            //Close lights
            lightController.turnLightsOFF();

            //Close door
            door.openCloseAnim.SetBool("open", false);
            door.audioDoor[0].PlayDelayed(0.55f);
            door.openable = false;

            //Start playing ambiental music
            //Not sure if this music fits the enviroment good enough
            //musicController.playNormal();

            //Destroy object
            Destroy(gameObject);
        }
    }
}