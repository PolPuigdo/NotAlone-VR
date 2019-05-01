using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualEnigmaController : MonoBehaviour
{
    public GameObject[] potPlaces;
    private int potCont = 0;
    public Candle[] candles;
    private int candleCont = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumPot()
    {
        potCont++;
    }

    public void lessPot()
    {
        potCont--;
    }

    public void sumCandle()
    {
        candleCont++;
    }

    public void checkIfDone()
    {
        if (potCont > 3 && candleCont > 4)
        {
            //The final Key apears
        }
    }
}
