using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseEnigmaController : MonoBehaviour
{
    public GameObject vaseNormal;
    public GameObject vaseBroken;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        vaseNormal.SetActive(true);
        vaseBroken.SetActive(false);
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void breakVase()
    {
        Destroy(vaseNormal);
        vaseBroken.SetActive(true);
        key.SetActive(true);
    }
}
