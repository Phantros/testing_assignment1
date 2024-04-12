using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] lanePositions;
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public float maxJumpTime = 0.5f; 
    public Rigidbody rb;
    private bool isGrounded = true;
    private bool isJumping = false;
    private float jumpTimeCounter;

    private int currentLane = 1;
    private Vector3 targetPosition;

    private void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            ContinueJump();
        }

        if (PlayerManager.Lives == 0)
        {
            GameManager.GameOver();
        }

        // Move the player towards the target position using lerp for smooth movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        PlayerManager.Distance += SpeedManager.Speed * Time.deltaTime;
    }

    private void MoveToLane(int laneIndex)
    {
        if (laneIndex >= 0 && laneIndex < lanePositions.Length && laneIndex != currentLane)
        {
            targetPosition = lanePositions[laneIndex].position;
            currentLane = laneIndex;
        }
    }

    private void StartJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpTimeCounter = maxJumpTime;
        isJumping = true;
        isGrounded = false;
    }

    private void ContinueJump()
    {
        if (jumpTimeCounter > 0)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GameOver(Clone)")
        {
            GameManager.GameOver();
        }

        if (other.gameObject.name == "Fence(Clone)" || other.gameObject.name == "Sway(Clone)")
        {
            Destroy(other.gameObject);
            PlayerManager.Lives -= 1;
            SpeedManager.DecreaseSpeed(1f);
        }

        if (other.gameObject.name == "OneCoin(Clone)")
        {
            Destroy(other.gameObject);
            SpeedManager.IncreaseSpeed(0.3f);
            PlayerManager.Score += 1;
            PlayerManager.Pickups += 1;
        }

        if (other.gameObject.name == "TwoCoin(Clone)")
        {
            Destroy(other.gameObject);
            SpeedManager.IncreaseSpeed(0.3f);
            PlayerManager.Score += 2;
            PlayerManager.Pickups += 1;
        }
    }
}
