using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool openable = true;
    private bool isOpen = false;
    private Animator openCloseAnim = null;
    private AudioSource[] audioDoor;//0-close 1-open 2-locked
    

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
            OpenDoor();

        } else if (openable && isOpen) //It can be opened and its open
        {
            CloseDoor();

        } else //It can't be opened
        {
            //Audio that it's closed
            audioDoor[2].Play();
        }
        
    }

    public virtual void OpenDoor()
    {
        openCloseAnim.SetBool("open", true);
        audioDoor[1].PlayDelayed(0.1f);
        isOpen = true;
    }

    public virtual void CloseDoor()
    {
        openCloseAnim.SetBool("open", false);
        audioDoor[0].PlayDelayed(0.55f);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
