using UnityEngine.SceneManagement;
using UnityEngine;

public static class GameManager
{
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");   
    }
}
