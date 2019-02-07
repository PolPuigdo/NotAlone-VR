using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour
{
    /*public float speed; 
    private Rigidbody rb2d;
    public SteamVR_Action_Vector2 touchPadAction;*/

    public SteamVR_Action_Vector2 touchPadAction;

    void Start()
    {
            
        //rb2d = GetComponent<Rigidbody>();

    }

    void Update()
    {

        if (SteamVR_Actions._default.Teleport.GetStateUp(SteamVR_Input_Sources.Any))
        {

        }


        /*Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

        rb2d.AddForce(touchpadValue * speed);*/
    }


    



}
