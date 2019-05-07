using UnityEngine;
using System.Collections;
using Valve.VR;

public class TouchPadMovement : MonoBehaviour
{
    public GameObject player;
    public SteamVR_Action_Vector2 touchPadAction;

    public Vector3 speedX;
    public Vector3 speedZ;

    private bool isRightFoot = true;

    private void Start()
    {
        //Sets the player to the 20.734 heigh because the terrain has an elevation of 20 + floor of the house
    }

    void FixedUpdate()
    {
        
        //Reads the touchpad values (x,y)
        Vector2 touchpad = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

        // Move 
        if (SteamVR_Actions._default.Movement.GetChanged(SteamVR_Input_Sources.Any))
        {
            //Moves the player in x and y depending on the axis from the touchpad and the orientation of the camera
            player.transform.position += (Camera.main.transform.right * touchpad.x + Camera.main.transform.forward * touchpad.y) * Time.deltaTime * 1.5f; //Movement on x and y
            player.transform.position = new Vector3(player.transform.position.x, 20.734f, player.transform.position.z);

            if (!GetComponent<AudioSource>().isPlaying)
            {
                PlayFootSteps();
            }
        }
        else
        {
            //Stops. Without this line the player some times slides
            player.transform.position += new Vector3(0,0);
        }

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
