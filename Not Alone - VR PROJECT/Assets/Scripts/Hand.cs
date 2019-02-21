﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction = null;
    public SteamVR_Action_Boolean triggerAction = null;
    public SteamVR_Action_Boolean doorTrigger = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;

    private PickDrop currentInteractable = null;
    private List<PickDrop> interactables = new List<PickDrop>();

    private Door doorInteracatble = null;

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
            //On click if it has no value picks the object
            if (currentInteractable == null) 
            {
                PickUp();
            }
            // If it has a value (an object held) it drops it
            else
            {
                Drop();
            }
            
        }
        if (currentInteractable != null)
        {
            if (triggerAction.GetStateDown(pose.inputSource)) //Trigger calls Light method
            {
                currentInteractable.Light();
            }
        }
        

        if (doorTrigger.GetStateDown(pose.inputSource))
        {
            doorInteracatble.DoorAction();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickDrop"))
        {
            interactables.Add(other.gameObject.GetComponent<PickDrop>());
        }

        if (other.gameObject.CompareTag("Door"))
        {
            doorInteracatble = other.gameObject.GetComponent<Door>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickDrop"))
        {
            interactables.Remove(other.gameObject.GetComponent<PickDrop>());
        }
        
        if (other.gameObject.CompareTag("Door"))
        {
            doorInteracatble = null;
        }
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