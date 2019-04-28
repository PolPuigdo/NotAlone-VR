using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction = null;
    public SteamVR_Action_Boolean triggerAction = null;
    public SteamVR_Action_Boolean doorTrigger = null;
    public SteamVR_Action_Boolean colorButtonTrigger = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;

    private FlashLightController flashLightInteractable = null;
    private List<FlashLightController> flashInteractables = new List<FlashLightController>();

    private ObjectPickUpAble objectInteractable = null;
    private List<ObjectPickUpAble> objectInteractables = new List<ObjectPickUpAble>();

    private Door doorInteractable = null;
    private Button buttonInteractable = null;
    private Radio radioInteractable = null;

    Collider controllerCollider;

    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    private void Start()
    {
        controllerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Makes it: click pickup/drop
        if (grabAction.GetLastStateDown(pose.inputSource))
        {
            //On click if it has no value picks the object
            if (flashLightInteractable == null) 
            {
                PickUpFlashLight();
            }
            // If it has a value (an object held) it drops it
            else
            {
                DropFlashLight();
            }
            
        }

        if (flashLightInteractable != null)
        {
            if (triggerAction.GetStateDown(pose.inputSource)) //Trigger calls Light method
            {
                flashLightInteractable.changeLight();
            }
        }

        if (doorTrigger.GetStateDown(pose.inputSource) && doorInteractable != null)
        {
            doorInteractable.DoorAction();

            //doorInteractable = null;
        }
        
        if (colorButtonTrigger.GetStateDown(pose.inputSource) && buttonInteractable != null)
        {
            buttonInteractable.setColorToCode();

            //buttonInteractable = null;
        }

        if (grabAction.GetStateDown(pose.inputSource))
        {
            if (objectInteractable == null)
            {
                PickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        if (triggerAction.GetStateDown(pose.inputSource) && radioInteractable != null)
        {
            radioInteractable.activateRadio();

            //radioInteractable = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FlashLight"))
        {
            flashInteractables.Add(other.gameObject.GetComponent<FlashLightController>());
        }

        if (other.gameObject.CompareTag("PickDrop"))
        {
            objectInteractables.Add(other.gameObject.GetComponent<ObjectPickUpAble>());
        }

        if (other.gameObject.CompareTag("Door"))
        {
            doorInteractable = other.gameObject.GetComponent<Door>();
        }

        if (other.gameObject.CompareTag("Button"))
        {
            buttonInteractable = other.gameObject.GetComponent<Button>();
        }

        if (other.gameObject.CompareTag("Radio"))
        {
            radioInteractable = other.gameObject.GetComponent<Radio>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FlashLight"))
        {
            flashInteractables.Remove(other.gameObject.GetComponent<FlashLightController>());
        }

        if (other.gameObject.CompareTag("PickDrop"))
        {
            objectInteractables.Remove(other.gameObject.GetComponent<ObjectPickUpAble>());
        }

        if (other.gameObject.CompareTag("Door"))
        {
            doorInteractable = null;
        }

        if (other.gameObject.CompareTag("Button"))
        {
            buttonInteractable = null;
        }

        if (other.gameObject.CompareTag("Radio"))
        {
            radioInteractable = null;
        }
    }

    public void PickUpFlashLight()
    {
        // Get the nearest one
        flashLightInteractable = GetNearestFlashLight();

        // Check if it's null
        if (!flashLightInteractable)
            return;

        // Check if it's already held
        if (flashLightInteractable.activeHand)
            flashLightInteractable.activeHand.DropFlashLight();

        // Set the position to the same as the controller
        flashLightInteractable.ApplyOffset(transform);

        // Atach the object
        Rigidbody targetBody = flashLightInteractable.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;

        //Set this hand to active
        flashLightInteractable.activeHand = this;
    }

    public void PickUpObject()
    {
        // Get the nearest one
        objectInteractable = GetNearestObject();

        // Check if it's null
        if (!objectInteractable)
            return;

        // Check if it's already held
        if (objectInteractable.activeHand)
            objectInteractable.activeHand.DropObject();

        // Set the position to the same as the controller
        objectInteractable.ApplyOffset(transform);

        // Atach the object
        Rigidbody targetBody = objectInteractable.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;

        //Set this hand to active
        objectInteractable.activeHand = this;
    }

    public void DropFlashLight()
    {
        // Check if it's null
        if (!flashLightInteractable)
            return;

        // Apply the velocity
        Rigidbody targetBody = flashLightInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();

        // Detach nad set variables to null
        joint.connectedBody = null;
        flashLightInteractable.activeHand = null;
        flashLightInteractable = null;
    }

    public void DropObject()
    {
        // Check if it's null
        if (!objectInteractable)
            return;

        // Apply the velocity
        Rigidbody targetBody = objectInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();

        // Detach nad set variables to null
        joint.connectedBody = null;
        objectInteractable.activeHand = null;
        objectInteractable = null;
    }

    private FlashLightController GetNearestFlashLight()
    {
        FlashLightController nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(FlashLightController interactable in flashInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }

    private ObjectPickUpAble GetNearestObject()
    {
        ObjectPickUpAble nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (ObjectPickUpAble interactable in objectInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
