using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberShadowScript : MonoBehaviour
{
    private string numberCode = "";
    private string correctCode = "-I-V-III";
    private AudioSource correctSound;

    public GameObject I;
    public GameObject II;
    public GameObject III;
    public GameObject IV;
    public GameObject V;
    public Door door;


    // Start is called before the first frame update
    void Start()
    {
        correctSound = GetComponent<AudioSource>();
    }

    public virtual void setNumber(string num)
    {
        numberCode += "" + num;

        checkCodeStatus();
    }

    void checkCodeStatus()
    {
        if (numberCode.Contains(correctCode))
        {
            door.openable = true;

            correctSound.Play();
            I.SetActive(false);
            II.SetActive(false);
            III.SetActive(false);
            IV.SetActive(false);
            V.SetActive(false);

            numberCode = "";
        }
    }
}
