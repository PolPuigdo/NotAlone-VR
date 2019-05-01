using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private AudioSource[] engineAudios; //0-Starting 1-Working
    public LightController lightController;
    public Radio radio;

    // Start is called before the first frame update
    void Start()
    {
        engineAudios = GetComponents<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Gear")
        {
            Destroy(collision.gameObject);
            StartCoroutine(startEngine());
        }
    }

    private IEnumerator startEngine()
    {
        engineAudios[0].Play();
        yield return new WaitForSeconds(engineAudios[0].clip.length);

        lightController.turnLightsON();

        //Activates the radio
        radio.hasElectricity = true;

        engineAudios[1].Play();
        yield return new WaitForSeconds(engineAudios[1].clip.length);
    }

}
