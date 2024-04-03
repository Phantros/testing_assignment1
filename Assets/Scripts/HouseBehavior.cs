using UnityEngine;

public class HouseBehavior : MonoBehaviour
{
    void Update()
    {
        MoveHouse();
    }

    private void MoveHouse()
    {
        transform.Translate(Vector3.back * SpeedManager.Speed * Time.deltaTime);
    }
}
