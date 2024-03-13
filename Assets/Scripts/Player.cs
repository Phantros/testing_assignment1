using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] lanePositions;
    public float movementSpeed = 5f;

    private int currentLane = 1;
    private Vector3 targetPosition;

    private void Start()
    {
        // Set the initial position to the position of lane 2
        transform.position = lanePositions[currentLane].position;
        targetPosition = transform.position;
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

        // Move the player towards the target position using lerp for smooth movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
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
}
