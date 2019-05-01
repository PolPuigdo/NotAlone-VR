using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject flame;
    public GameObject flameLight;
    public Material emissionSourceMaterial;
    public bool isLight = false;

    // Start is called before the first frame update
    void Start()
    {
        flameLight.SetActive(false);
        flame.SetActive(false);
        emissionSourceMaterial.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lighter")
        {
            lightCandle();
        }
    }

    public virtual void lightCandle()
    {
        emissionSourceMaterial.EnableKeyword("_EMISSION");
        flame.SetActive(true);
        flameLight.SetActive(true);
        isLight = true;
    }
}
