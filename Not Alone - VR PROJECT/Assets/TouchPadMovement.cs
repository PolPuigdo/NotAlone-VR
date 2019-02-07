using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadMovement : MonoBehaviour
{
    public GameObject player;

    SteamVR_TrackedObject controller;

    public SteamVR_Action_Vector2 touchPadAction;

    void Start()
    {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        do
        {
            //Read the touchpad values
            Vector2 touchpad = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);


            // Handle movement via touchpad
            if (touchpad.y > 0.2f || touchpad.y < -0.2f || touchpad.x > 0.3f || touchpad.x < -0.3f)
            {
                // Move 
                player.transform.position -= player.transform.forward * Time.deltaTime * (touchpad.y * 5f); // Fordward / backward
                player.transform.position -= player.transform.right * Time.deltaTime * (touchpad.x * 5f); // Sides

            }

        } while (SteamVR_Actions._default.PressTouchPad.GetStateUp(SteamVR_Input_Sources.Any)); //while the touchpad is pressed
    }
}