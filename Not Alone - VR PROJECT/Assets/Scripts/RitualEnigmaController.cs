using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualEnigmaController : MonoBehaviour
{
    //public GameObject[] potPlaces;
    private int potCont = 0;
    //public Candle[] candles;
    private int candleCont = 0;
    public GameObject key;
    public GameObject lightKey;
    private AudioSource scream;

    private void Start()
    {
        key.SetActive(false);
        lightKey.SetActive(false);
        scream = GetComponent<AudioSource>();
    }

    public void sumPot()
    {
        potCont++;
        checkIfDone();
    }

    public void lessPot()
    {
        potCont--;
    }

    public void sumCandle()
    {
        candleCont++;
        checkIfDone();
    }

    public void checkIfDone()
    {
        if (potCont > 3 && candleCont > 4)
        {
            scream.Play();
            key.SetActive(true);
            lightKey.SetActive(true);
        }
    }
}
