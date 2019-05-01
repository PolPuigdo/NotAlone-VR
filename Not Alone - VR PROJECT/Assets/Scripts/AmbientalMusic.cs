using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientalMusic : MonoBehaviour
{
    private static AudioSource[] ambientalMusics; //0-Normal 1-SecretRoom

    // Start is called before the first frame update
    void Start()
    {
        ambientalMusics = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playNormal()
    {
        if (ambientalMusics[1].isPlaying)
        {
            ambientalMusics[1].Stop();
        }
        ambientalMusics[0].loop = true;
        ambientalMusics[0].PlayDelayed(2);
    }

    public void playScary()
    {
        if (ambientalMusics[0].isPlaying)
        {
            ambientalMusics[0].Stop();
        }
        ambientalMusics[1].loop = true;
        ambientalMusics[1].Play();
    }
}
