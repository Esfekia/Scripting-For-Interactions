using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    // Player's movement parameters
    public Vector3 direction;
    public float speed;

    public Rigidbody rb; // The Player's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // All physics calculations work with FixedUpdate
    void FixedUpdate()
    {
        // Creating a velocity vector
        // transform.Translate(direction * speed * Time.deltaTime);

        // Make world direction into local direction
        Vector3 localDirection = transform.TransformDirection(direction);
        // Move using physics!
        rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
    }

    // OnPlayerMove event handler
    public void OnPlayerMove(InputValue value)
    {
        // A vector with x and y components corresponding to the players 
        // WASD and arrow inputs. Both components in range [-1,1]
        Vector2 Inputvector = value.Get<Vector2>();
        
        // Move in the XZ-plane
        direction.x = Inputvector.x;
        direction.z = Inputvector.y;

    }
}
