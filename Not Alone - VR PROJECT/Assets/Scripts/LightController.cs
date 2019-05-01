using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnLightsON()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
    }

    public void turnLightsOFF()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
    }
}
