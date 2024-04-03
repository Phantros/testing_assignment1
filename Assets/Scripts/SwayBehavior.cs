using UnityEngine;

public class SwayBehavior : MonoBehaviour
{
    public float swaySpeed;
    private float leftBound;
    private float rightBound;
    private int direction = 1;
    private Vector3 nextPosition;

    void Start()
    {
        leftBound = transform.Find("LeftBound").position.x;
        rightBound = transform.Find("RightBound").position.x;
    }

    void Update()
    {
        nextPosition = transform.position + Vector3.right * swaySpeed * Time.deltaTime * direction;
        SwaySway();
        MoveSway();
    }

    private void SwaySway()
    {
        if (direction > 0 && nextPosition.x >= rightBound)
        {
            direction = -1;
        }
        else if (direction < 0 && nextPosition.x <= leftBound)
        {
            direction = 1;
        }

        transform.position = nextPosition;
    }

    private void MoveSway()
    {
        transform.Translate(Vector3.right * SpeedManager.Speed * Time.deltaTime);
    }
}
