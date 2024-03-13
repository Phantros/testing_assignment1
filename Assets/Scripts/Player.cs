using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] lanePositions; // Array to store lane positions
    private int currentLane = 1; // Initial lane

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
    }

    // Check if the lane index is valid and not the same as the current lane, if so, move the player there and update the current lane. 
    private void MoveToLane(int laneIndex)
    {
        if (laneIndex >= 0 && laneIndex < lanePositions.Length && laneIndex != currentLane)
        {
            transform.position = lanePositions[laneIndex].position;
            currentLane = laneIndex; 
        }
    }
}
