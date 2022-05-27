using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    // The object that the raycast is currently hitting
    public GameObject focusedObject;
    
    public GameObject pickupSlot;

    public float InteractDistance;

    public bool holding;

    private void FixedUpdate()
    {
        // If player is holding an object, return
        if(holding)        
            return;
        // Compute the player's forward direction
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // hit var to store our results
        RaycastHit hit;

        // ray originating from the camera (forward vector of the game object, not screen)
        Ray ray = new Ray(transform.position, fwd);

        // Conduct the raycast

        if (Physics.Raycast(ray, out hit))
        {
            focusedObject = hit.collider.gameObject;
        }
        else
        {
            focusedObject = null;
        }
    }

    public void onInteract()
    {

    }
}
