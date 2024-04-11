using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinSpeed
{
    [UnityTest]
    public IEnumerator CoinSpeedTest()
    {
        Assert.AreEqual(SpeedManager.Speed, 5);
        
        yield return new WaitForSeconds(1);

        for (int i = 0; i < 50; i++)
        {
            SpeedManager.IncreaseSpeed(0.3f * i);
                
            Assert.GreaterOrEqual(SpeedManager.Speed, 5);
        }       
    }
}
