using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool openable = true;
    private bool isOpen = false;
    public Animator openCloseAnim = null;
    public AudioSource[] audioDoor;//0-close 1-open 2-locked
    

    // Start is called before the first frame update
    void Start()
    {
        openCloseAnim = GetComponent<Animator>();
        audioDoor = GetComponents<AudioSource>();
    }

    public virtual void DoorAction()
    {
        if (openable && !isOpen) //It can be opened and its closed
        {
            //Opens door
            openCloseAnim.SetBool("open", true);
            audioDoor[1].PlayDelayed(0.1f);
            isOpen = true;
        } else if (openable && isOpen) //It can be opened and its open
        {
            //Closes door
            openCloseAnim.SetBool("open", false);
            audioDoor[0].PlayDelayed(0.55f);
            isOpen = false;
        } else //It can't be opened
        {
            //Audio that it's closed
            audioDoor[2].Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
