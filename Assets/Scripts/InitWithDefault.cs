using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System;
using UnityEngine.Analytics;
using System.Collections.Generic;
using CustomEvent = Unity.Services.Analytics.CustomEvent;

public class InitWithDefault : MonoBehaviour
{
    public static event EventHandler AnalyticsInitializedSuccessfully;
    private int coins;
    private float speed;

    async void Start()
    {
        await UnityServices.InitializeAsync();

        AnalyticsInitializedSuccessfully?.Invoke(this, new EventArgs());
        AskForConsent();
    }

    void AskForConsent()
    {
        // ... show the player a UI element that asks for consent.
        ConsentGiven();
    }

    void ConsentGiven()
    {
        AnalyticsService.Instance.StartDataCollection();
    }

    public void RetryButtonClick()
    {
        AnalyticsService.Instance.RecordEvent("retryButtonClicked");
    }

    public void NextLevelTwoClick()
    {
        AnalyticsService.Instance.RecordEvent("levelTwoButtonClicked");
    }

    public void NextLevelThreeClick()
    {
        AnalyticsService.Instance.RecordEvent("levelThreeButtonClicked");
    }

    public void GameFinished()
    {
        AnalyticsService.Instance.RecordEvent("gameFinished");
    }

    public void LevelStarted()
    {
        AnalyticsService.Instance.RecordEvent("levelStarted");
    }

    public void PlayerDied()
    {
        AnalyticsService.Instance.RecordEvent("playerDied");
    }

    public void LevelWon(string level)
    {
        if(level == "Level1")
            AnalyticsService.Instance.RecordEvent("levelOneWon");

        if (level == "Level2")
            AnalyticsService.Instance.RecordEvent("levelTwoWon");

        if (level == "Level3")
            AnalyticsService.Instance.RecordEvent("levelThreeWon"); 
    }

    public void MaxSpeedReached(float maxSpeed)
    {
        speed += maxSpeed;

        CustomEvent myEvent = new CustomEvent("maxSpeedReached")
        {
            { "speed", speed }
        };

        AnalyticsService.Instance.RecordEvent(myEvent);
    }

    public void CoinsCollected(int numberOfCoins)
    {
        coins += numberOfCoins;

        CustomEvent myEvent = new CustomEvent("coinsCollected")
        {
            { "coins", coins }
        };

        // Record the coinsCollected event with the number of coins collected
        AnalyticsService.Instance.RecordEvent(myEvent);
    }
}
