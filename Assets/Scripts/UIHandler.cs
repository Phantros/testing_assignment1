using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void GoToLevelOne()
    {
        PlayerManager.Reset();
        SpeedManager.Reset();
        SceneManager.LoadScene("Level1");
    }
}
