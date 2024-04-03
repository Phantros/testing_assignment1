using UnityEngine;

public class LaneStripeBehavior : MonoBehaviour
{
    public Transform[] stripes; // Array of stripes in the lane
    //public float speed = 5f; // Speed of movement
    private float laneLength; // Length of the lane
    public Transform spawnPoint; // Reference point for the start of the lane

    void Start()
    {
        laneLength = transform.localScale.z;
    }

    void Update()
    {
        // Move each stripe in the lane
        foreach (Transform stripe in stripes)
        {
            stripe.Translate(Vector3.back * SpeedManager.Speed * Time.deltaTime);

            // Check if the stripe reaches the end of the lane
            if (stripe.localPosition.z <= -laneLength)
            {
                stripe.transform.position = spawnPoint.transform.position; // Move the stripe back to the start
            }
        }
    }
}
