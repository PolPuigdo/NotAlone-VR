using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaColorsController : MonoBehaviour
{
    public string codeColor = "";
    private string correctCode = "BlueGreenBlueRed";
    private AudioSource correctSound;

    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public Door door;


    // Start is called before the first frame update
    void Start()
    {
        correctSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void setColor(string color)
    {
        codeColor += ""+color;

        checkColorStatus();
    }

    void checkColorStatus()
    {
    if (codeColor.Contains(correctCode))
        {
            door.openable = true;

            correctSound.Play();
            red.SetActive(false);
            blue.SetActive(false);
            green.SetActive(false);

            codeColor = "";
        }
    }
}
