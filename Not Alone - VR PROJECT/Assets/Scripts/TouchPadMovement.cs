using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadMovement : MonoBehaviour
{
    public GameObject player;

    public SteamVR_Action_Vector2 touchPadAction;

    void Start()
    {
    }

    void Update()
    {
        do
        {
            //Read the touchpad values
            Vector2 touchpad = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

            // Move 
            player.transform.position += (Camera.main.transform.right * touchpad.x + Camera.main.transform.forward * touchpad.y) * Time.deltaTime * 3f; //Movement in x and y
            player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z); //Set the player in the ground

        } while (SteamVR_Actions._default.PressTouchPad.GetStateUp(SteamVR_Input_Sources.Any)); //while the touchpad detects the finger(touch)
    }
}