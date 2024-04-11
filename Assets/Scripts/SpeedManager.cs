using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedManager
{
    public static float speed = 5.0f; 

    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
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

    public static void Reset()
    {
        speed = 5;
    }
}
