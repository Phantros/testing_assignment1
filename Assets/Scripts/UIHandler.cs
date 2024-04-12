using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void GameFinished()
    {
        Application.Quit();
    }

    public void GoToLevelOne()
    {
        PlayerManager.Reset();
        SpeedManager.Reset();
        SceneManager.LoadScene("Level1");
    }

    public void GoToLevelTwo()
    {
        PlayerManager.Reset();
        SpeedManager.Reset();
        SceneManager.LoadScene("Level2");
    }

    public void GoToLevelThree()
    {
        PlayerManager.Reset();
        SpeedManager.Reset();
        SceneManager.LoadScene("Level3");
    }
}
