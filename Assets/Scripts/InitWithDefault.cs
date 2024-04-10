using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System;

public class InitWithDefault : MonoBehaviour
{
	public static event EventHandler AnalyticsInitializedSuccessfully;
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
	void RecordCustomEvent()
	{
		AnalyticsService.Instance.RecordEvent("buttonClicked");
	}
	public void ButtonClick()
	{
		RecordCustomEvent();
		Debug.Log("Clicked Button");
	}
}
