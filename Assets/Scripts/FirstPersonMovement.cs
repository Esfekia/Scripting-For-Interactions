using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    // Player's movement parameters
    public Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Creating a velocity vector
        transform.Translate(direction * speed * Time.deltaTime);
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
