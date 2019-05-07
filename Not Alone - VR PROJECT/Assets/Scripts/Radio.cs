using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private bool hasCassette = false;
    public bool hasElectricity = false;

    private AudioSource[] radioAudios; //0-Button 1-Interferences 2-Red 3-Green 4-Blue

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cassette")
        {
            if (radioAudios[1].isPlaying)
            {
                radioAudios[1].Stop();
            }

            Destroy(collision.gameObject);
            hasCassette = true;
        }
    }

    private void Start()
    {
        radioAudios = GetComponents<AudioSource>();
    }

    public virtual void activateRadio()
    {
        if (hasElectricity)
        {
            if (hasCassette)
            {
                StartCoroutine(cassetteAction());
            }
            else
            {
                radioAudios[0].Play();
                noCassetteAction();
            }
        } else
        {
            radioAudios[0].Play();
        }
    }

    private void noCassetteAction()
    {
        if (!radioAudios[1].isPlaying)
        {
            radioAudios[1].Play();
            radioAudios[1].loop = true;
        }
        else
        {
            radioAudios[1].Stop();
        }
    }

    private IEnumerator cassetteAction()
    {
        radioAudios[0].Play();
        yield return new WaitForSeconds(radioAudios[0].clip.length);

        radioAudios[4].Play();
        yield return new WaitForSeconds(radioAudios[4].clip.length);

        radioAudios[3].Play();
        yield return new WaitForSeconds(radioAudios[3].clip.length);

        radioAudios[4].Play();
        yield return new WaitForSeconds(radioAudios[4].clip.length);

        radioAudios[2].Play();
        yield return new WaitForSeconds(radioAudios[2].clip.length);

        radioAudios[3].Play();
        yield return new WaitForSeconds(radioAudios[3].clip.length);
    }
}
