using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TMPro;

public class Level1ManagerTest
{
    [UnityTest]
    public IEnumerator CountdownTimer_StartsAtCorrectValue_CountsDownToZero_EnablesPlayer()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        Transform[] lanePositions = new Transform[3];
        for (int i = 0; i < 3; i++)
        {
            GameObject laneObject = new GameObject("LanePosition" + i);
            lanePositions[i] = laneObject.transform;
        }
        player.lanePositions = lanePositions;

        GameObject countdownTextObject = new GameObject();
        TextMeshProUGUI countdownText = countdownTextObject.AddComponent<TextMeshProUGUI>();

        GameObject level1ManagerObject = new GameObject();
        Level1Manager level1Manager = level1ManagerObject.AddComponent<Level1Manager>();
        level1Manager.countdownText = countdownText;
        level1Manager.player = player;

        level1Manager.InitializeLevel();
        yield return new WaitForSeconds(4f); 
        
        Assert.AreEqual("GO", countdownText.text);
        Assert.IsTrue(player.enabled);
    }
}
