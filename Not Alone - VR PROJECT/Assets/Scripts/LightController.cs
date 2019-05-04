using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject[] lights;

 

    public virtual void turnLightsON()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
    }

    public virtual void turnLightsOFF()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
    }
}
