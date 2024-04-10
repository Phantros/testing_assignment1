using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] lanePositions;
    public float movementSpeed = 5f;
    public float jumpForce = 10f; 
    public Rigidbody rb;
    private bool isGrounded = true;

    private int currentLane = 1;
    private Vector3 targetPosition;

    private void Start()
    {
        // Set the initial position to the position of lane 2
        transform.position = lanePositions[currentLane].position;
        targetPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToLane(0); 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToLane(1); 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToLane(2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Move the player towards the target position using lerp for smooth movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        PlayerManager.Distance += SpeedManager.Speed * Time.deltaTime;
    }

    // Check if the lane index is valid and not the same as the current lane
    // If so, set the target position to the lane position and update the current lane
    private void MoveToLane(int laneIndex)
    {
        if (laneIndex >= 0 && laneIndex < lanePositions.Length && laneIndex != currentLane)
        {
            targetPosition = lanePositions[laneIndex].position;
            currentLane = laneIndex; 
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Fence" || other.gameObject.name == "Sway")
        {
            Destroy(other.gameObject);
            PlayerManager.Lives -= 1;
            SpeedManager.DecreaseSpeed(1f);
        }

        if(other.gameObject.name == "OneCoin")
        {
            Destroy(other.gameObject);
            SpeedManager.IncreaseSpeed(0.3f);
            PlayerManager.Score += 1;
        }

        if(other.gameObject.name == "TwoCoin")
        {
            Destroy(other.gameObject);
            SpeedManager.IncreaseSpeed(0.3f);
            PlayerManager.Score += 2;
        }
    }
}
