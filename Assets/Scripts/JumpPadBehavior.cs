using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehavior : MonoBehaviour
{
    public float jumpForce;

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            playerRb.AddForce(other.transform.up * jumpForce, ForceMode.Impulse);
            Debug.Log("entered!");
        }
    }

}
