using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject flame;
    public GameObject flameLight;
    public Material emissionSourceMaterial;
    public bool isLight = false;
    public Lighter lighter;
    public RitualEnigmaController controller;

    // Start is called before the first frame update
    void Start()
    {
        flameLight.SetActive(false);
        flame.SetActive(false);
        emissionSourceMaterial.DisableKeyword("_EMISSION");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lighter" && lighter.isOn)
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

        controller.sumCandle();
    }
}
