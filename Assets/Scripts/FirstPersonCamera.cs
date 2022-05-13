using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    // The camera attached to the player
    public Camera playerCamera;

    // Container variables for the mouse delta values each frame
    public float deltaX;
    public float deltaY;

    // Container variables to keep track of player's rotation around X and Y axes
    public float xRot; //Rotation around the x-axis in degrees
    public float yRot; //Rotation around the y-axis in degrees

    // Container variable for sensitivity
    public Vector2 sensitivity;


    
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main; // set player camera
        Cursor.visible = false; // hide the cursor
                
    }

    // Update is called once per frame
    void Update()
    {
        // Keep track of player's x and y rotation
        yRot += deltaX * Time.deltaTime;
        xRot -= deltaY * Time.deltaTime;

        // Clamp x-rotation so they cannot rotate all the way to back:
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //rotate the camera around x-axis
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    //OnCameraLook event handler
    public void OnCameraLook(InputValue value)
    {
        // Reading the mouse deltas as a vector2 (deltaX/deltaY)
        Vector2 inputVector = value.Get<Vector2>() * sensitivity;
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}

