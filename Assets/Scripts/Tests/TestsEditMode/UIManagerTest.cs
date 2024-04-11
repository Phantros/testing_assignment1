using NUnit.Framework;
using UnityEngine;
using TMPro;

public class UIManagerTest
{
    [Test]
    public void UIManager_Start_SetsInitialText()
    {
        GameObject uiManagerObject = new GameObject();
        UIManager uiManager = uiManagerObject.AddComponent<UIManager>();

        TextMeshProUGUI livesText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.lives = livesText;

        TextMeshProUGUI pickupsText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.pickups = pickupsText;

        TextMeshProUGUI distanceText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.distance = distanceText;

        TextMeshProUGUI scoreText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.score = scoreText;

        uiManager.Start();

        Assert.AreEqual("Lives: ", livesText.text);
        Assert.AreEqual("Pickups: ", pickupsText.text);
        Assert.AreEqual("Distance: ", distanceText.text);
        Assert.AreEqual("Score: ", scoreText.text);
    }

    [Test]
    public void UIManager_UpdateUI_UpdatesUIText()
    {
        GameObject uiManagerObject = new GameObject();
        UIManager uiManager = uiManagerObject.AddComponent<UIManager>();

        TextMeshProUGUI livesText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.lives = livesText;

        TextMeshProUGUI pickupsText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.pickups = pickupsText;

        TextMeshProUGUI distanceText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.distance = distanceText;

        TextMeshProUGUI scoreText = new GameObject().AddComponent<TextMeshProUGUI>();
        uiManager.score = scoreText;

        uiManager.UpdateUI();

        Assert.AreEqual("Lives: " + PlayerManager.Lives, livesText.text);
        Assert.AreEqual("Pickups: " + PlayerManager.Pickups, pickupsText.text);
        Assert.AreEqual("Distance: " + PlayerManager.Distance, distanceText.text); 
        Assert.AreEqual("Score: " + PlayerManager.Score, scoreText.text);
    }
}
