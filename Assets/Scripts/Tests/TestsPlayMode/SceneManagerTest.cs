using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SceneManagerTest
{
    [UnityTest]
    public IEnumerator Level1ToGameOverSceneTransition()
    {
        SceneManager.LoadScene("Level1");
        yield return null;

        GameManager.GameOver();

        yield return null;

        Assert.AreEqual("GameOver", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator RetryButtonStartsLevel1Scene()
    {
        SceneManager.LoadScene("GameOver");
        yield return null; 

        GameObject UIHandler = GameObject.Find("UIHandler");
        Assert.NotNull(UIHandler, "UIHandler Not Found");

        UIHandler.GetComponent<UIHandler>().GoToLevelOne();

        yield return new WaitForSeconds(2f);

        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void GameStateIsResetOnLevelRetry()
    {
        PlayerManager.Reset();
        SpeedManager.Reset();

        SceneManager.LoadScene("Level1");

        Assert.AreEqual(3, PlayerManager.Lives);
        Assert.AreEqual(0, PlayerManager.Score);
        Assert.AreEqual(0, PlayerManager.Distance);

        Assert.AreEqual(5, SpeedManager.Speed);
    }
}
