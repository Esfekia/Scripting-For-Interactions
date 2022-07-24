using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    // The container for referencing the object that the raycast is currently hitting
    public GameObject focusedObject;
    
    public GameObject pickupSlot;

    // distance where player will be able to pick up things
    public float interactDistance;


    // boolean to see if player is holding something, this will affect what interact will do.
    public bool holding;

    private void FixedUpdate()
    {
        // if player is holding an object, no need to cast a ray, just return
        if(holding)        
            return;
        // compute the player's forward direction
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // hit var to store our results
        RaycastHit hit;

        // ray originating from the camera (forward vector of the game object, not screen)
        Ray ray = new Ray(transform.position, fwd);

        // Conduct the raycast

        if (Physics.Raycast(ray, out hit))
        {
            // if we hit something, we have it in focus
            focusedObject = hit.collider.gameObject;
        }
        else
        {
            // if we are not looking at anything, no focus object
            focusedObject = null;
        }
    }

    public void onInteract()
    {
        // if we are holding something and we hit E, then we should drop it
        //(below is cimplete opposite of the not holding part underneath. read that to understand it first.)
        if (holding)
        {
            // drop what we are holding
            // separate from parent
            focusedObject.transform.parent = null;
            // make it not kinematic
            focusedObject.GetComponent<Rigidbody>().isKinematic = false;
            // set holding false for the if / else if checks
            holding = false;
        }
        // check if the focused item is interactable, and then pick it up.
        // you can use other tags here for other actions. i.e. if door, open it, etc.
        else if (focusedObject.CompareTag("Interactable"))
        {
            // pick up the barrel. make it pickupSlot's child and then set its position same as pickupSlot
            focusedObject.transform.parent = pickupSlot.transform;
            focusedObject.transform.position = pickupSlot.transform.position;

            // ensure motion is not affected by physics and only by player moving around
            focusedObject.GetComponent<Rigidbody>().isKinematic = true;

            // set holding true for the if / else if checks
            holding = true;
        }
         
    }
}
