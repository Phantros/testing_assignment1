using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    void Update()
    {
        MoveCoin();
    }

    private void MoveCoin()
    {
        transform.Translate(Vector3.back * SpeedManager.Speed * Time.deltaTime);
    }
}
