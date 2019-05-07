using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextController : MonoBehaviour
{
    /*This class is because the numbers can be seen through the walls. This class will activate the text when the player enters the kitchen
    and deactivate it when the player goes out avoiding some possible bugs*/

    public GameObject I;
    public GameObject II;
    public GameObject III;
    public GameObject IV;
    public GameObject V;

    public bool insideRoom;

    private void Start()
    {
        deactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (insideRoom)
            {
                deactivate();

            } else
            {
                activate();
            }

        }
    }

    private void activate()
    {
        I.SetActive(true);
        II.SetActive(true);
        III.SetActive(true);
        IV.SetActive(true);
        V.SetActive(true);

        insideRoom = true;
    }

    private void deactivate()
    {
        I.SetActive(false);
        II.SetActive(false);
        III.SetActive(false);
        IV.SetActive(false);
        V.SetActive(false);

        insideRoom = false;
    }
}
