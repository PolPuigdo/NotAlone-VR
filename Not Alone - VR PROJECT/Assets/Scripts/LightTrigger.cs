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



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            //Play sound
            tensionSound.Play();

            //Close lights
            lightController.turnLightsOFF();

            //Close door
            door.CloseDoor();

            //Better to let the player enter again to the init room
            //cause if he doesn't take the gear with him, he would get stuck
            //door.openable = false;

            //Start playing ambiental music
            //Not sure if this music fits the enviroment good enough
            musicController.playNormal();

            //Destroy object
            Destroy(gameObject);
        }
    }
}