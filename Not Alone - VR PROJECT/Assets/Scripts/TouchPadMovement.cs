using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadMovement : MonoBehaviour
{
    public GameObject player;

    public SteamVR_Action_Vector2 touchPadAction;

    // Executes once per frame
    void Update()
    {
        do
        {
            //Read the touchpad values
            Vector2 touchpad = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

            // Move 
            player.transform.position += (Camera.main.transform.right * touchpad.x + Camera.main.transform.forward * touchpad.y) * Time.deltaTime * 1.75f; //Movement in x and y
            player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z); //Set the player in the ground

            if (!GetComponent<AudioSource>().isPlaying && SteamVR_Actions._default.PressTouchPad.GetStateUp(SteamVR_Input_Sources.Any))
            {
                PlayFootSteps();
            }

        } while (SteamVR_Actions._default.PressTouchPad.GetStateUp(SteamVR_Input_Sources.Any)); //while the touchpad detects the finger(touch)
    }

    private void PlayFootSteps()
    {
        GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);

        GetComponent<AudioSource>().Play();
    }
}