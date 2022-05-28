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
    public float InteractDistance;


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

    }
}
