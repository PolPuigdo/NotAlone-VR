using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction = null;
    public SteamVR_Action_Boolean triggerAction = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;

    private PickDrop currentInteractable = null;
    private List<PickDrop> interactables = new List<PickDrop>();

    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    private void Update()
    {

        //Makes it: click pickup/drop
        if (grabAction.GetLastStateDown(pose.inputSource))
        {
            if (currentInteractable == null) //On click if it has no value picks the object
            {
                PickUp();
            } else // If it has a value (an object held) it drops it
            {
                Drop();
            }
            
        }
        if (currentInteractable != null)
        {
            if (triggerAction.GetStateDown(pose.inputSource))
            {
                currentInteractable.Light();
            }
        }
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PickDrop"))
            return;

        interactables.Add(other.gameObject.GetComponent<PickDrop>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("PickDrop"))
            return;

        interactables.Remove(other.gameObject.GetComponent<PickDrop>());
    }

    public void PickUp()
    {
        // Get the nearest one
        currentInteractable = GetNearestObject();

        // Check if it's null
        if (!currentInteractable)
            return;

        // Check if it's already held
        if (currentInteractable.activeHand)
            currentInteractable.activeHand.Drop();

        // Set the position to the same as the controller
        currentInteractable.ApplyOffset(transform);

        // Atach the object
        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;

        //Set this hand to active
        currentInteractable.activeHand = this;
    }

    public void Drop()
    {
        // Check if it's null
        if (!currentInteractable)
            return;

        // Apply the velocity
        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();

        // Detach nad set variables to null
        joint.connectedBody = null;
        currentInteractable.activeHand = null;
        currentInteractable = null;
    }

    private PickDrop GetNearestObject()
    {
        PickDrop nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(PickDrop interactable in interactables)
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
}
