using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool openable = true;
    private bool isOpen = false;
    private Animator openCloseAnim = null;

    // Start is called before the first frame update
    void Start()
    {
        openCloseAnim = GetComponent<Animator>();
    }

    public virtual void DoorAction()
    {
        if (openable && !isOpen) //It can be opened and its closed
        {
            openCloseAnim.SetBool("open", true);
            //Play audio
            isOpen = true;
        } else if (openable && isOpen) //It can be opened and its open
        {
            openCloseAnim.SetBool("open", false);
            //Play audio
            isOpen = false;
        } else //It can't be opened
        {
            //Play sound
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
