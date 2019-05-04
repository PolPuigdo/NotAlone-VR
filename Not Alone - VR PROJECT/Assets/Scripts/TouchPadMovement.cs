using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadMovement : MonoBehaviour
{
    public GameObject player;
    public SteamVR_Action_Vector2 touchPadAction;

    private bool isRightFoot = true;

    // Executes once per frame
    void Update()
    {
        //do
        //{
            //Read the touchpad values
            Vector2 touchpad = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

            // Move 
            player.transform.position += (Camera.main.transform.right * touchpad.x + Camera.main.transform.forward * touchpad.y) * Time.deltaTime * 1.5f; //Movement on x and y
            player.transform.position = new Vector3(player.transform.position.x, 20.034f, player.transform.position.z); //Set the player in the ground. The y is at 20 because the terrain heigh is 20

            if (!GetComponent<AudioSource>().isPlaying && SteamVR_Actions._default.Movement.GetChanged(SteamVR_Input_Sources.Any))
            {
                PlayFootSteps();
            }

        //} while (SteamVR_Actions._default.PressTouchPad.GetStateUp(SteamVR_Input_Sources.Any)); //while the touchpad detects the finger(touch)
    }



    private void PlayFootSteps()
    {
        //Prioritize the footsteps on the right/left headphone
        if (isRightFoot)
        {
            GetComponent<AudioSource>().panStereo = 0.6f; //Right headphone
            isRightFoot = false;
        } else
        {
            GetComponent<AudioSource>().panStereo = -0.6f; //Left headphone
            isRightFoot = true;
        }

        //Changing the volume and pitch with random numbers so it's more realistic
        GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        

        GetComponent<AudioSource>().Play();
    }
}