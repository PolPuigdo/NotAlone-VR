using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePot : MonoBehaviour
{
    //The itHas bool prevents the player from putting 2 or more pots in the same spot
    public bool itHas = false;

    public RitualEnigmaController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Pot") && !itHas)
        {
            controller.sumPot();
            itHas = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Pot") && itHas){
            controller.lessPot();
            itHas = false;
        }
    }
}
