using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedManager
{
    private static float speed = 5.0f; 

    public static float Speed
    {
        get { return speed; }
    }

    public static void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    public static void DecreaseSpeed(float amount)
    {
        speed -= amount;
        if (speed < 0)
        {
            speed = 0;
        }
    }
}
