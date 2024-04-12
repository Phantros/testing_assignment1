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

        Debug.Log("got synced");
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

    public void ButtonClick()
    {
        AnalyticsService.Instance.RecordEvent("retryButtonClicked");
    }

    public void LevelStarted()
    {
        AnalyticsService.Instance.RecordEvent("levelStarted");
        Debug.Log("Level started");
    }

    public void PlayerDied()
    {
        AnalyticsService.Instance.RecordEvent("playerDied");
    }

    public void LevelWon()
    {
        AnalyticsService.Instance.RecordEvent("levelWon");
    }

    public void MaxSpeedReached(float maxSpeed)
    {
        speed += maxSpeed;

        CustomEvent myEvent = new CustomEvent("maxSpeedReached")
        {
            { "speed", speed }
        };

        AnalyticsService.Instance.RecordEvent(myEvent);

        Debug.Log("Max Speed Sent");
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

        Debug.Log("Coins data sent");
    }
}
