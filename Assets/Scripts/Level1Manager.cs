using UnityEngine;
using System.Collections;
using TMPro;

public class Level1Manager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI countdownText;

    public void Start()
    {
        InitializeLevel();
    }
    // Call this method to initialize the level
    public void InitializeLevel()
    {
        player.enabled = false;
        SpeedManager.Speed = 0;

        StartCoroutine(StartLevelCountdown());
    }

    IEnumerator StartLevelCountdown()
    {
        int countdownValue = 3;

        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }

        countdownText.text = "GO";

        player.enabled = true;
        SpeedManager.Reset();

        yield return new WaitForSeconds(0.8f);

        countdownText.gameObject.SetActive(false);
    }
}
