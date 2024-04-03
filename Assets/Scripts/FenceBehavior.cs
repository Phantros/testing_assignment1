using UnityEngine;

public class FenceBehavior : MonoBehaviour
{
    void Update()
    {
        MoveFence();
    }

    private void MoveFence()
    {
        transform.Translate(Vector3.back * SpeedManager.Speed * Time.deltaTime);
    }
}
