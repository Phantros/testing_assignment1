using UnityEngine.SceneManagement;
using UnityEngine;

public static class GameManager
{
    public static void GameFinished()
    {
        Application.Quit();
        SceneManager.LoadScene("GameOver");
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void LevelWon(string level)
    {
        if (level == "Level1")
        {
            SceneManager.LoadScene("LevelOneWon");
        }

        if (level == "Level2")
        {
            SceneManager.LoadScene("LevelTwoWon");
        }

        if (level == "Level3")
        {
            SceneManager.LoadScene("LevelThreeWon");
        }
    }

    /*
        public static void LevelOneWon()
        {
            SceneManager.LoadScene("LevelOneWon"); 
        }

        public static void LevelTwoWon()
        {
            SceneManager.LoadScene("LevelTwoWon");
        }

        public static void LevelThreeWon()
        {
            SceneManager.LoadScene("LevelThreeWon");
        }*/
}
