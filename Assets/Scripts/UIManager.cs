using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI lives;
    public TextMeshProUGUI pickups;
    public TextMeshProUGUI distance;
    public TextMeshProUGUI score;

    public void Update()
    {
        UpdateUI();
    }

    public void Start()
    {
        lives.SetText("Lives: ");
        pickups.SetText("Pickups: ");
        distance.SetText("Distance: ");
        score.SetText("Score: ");
    }

    public void UpdateUI()
    {
        int realLives = PlayerManager.Lives;
        int realPickups = PlayerManager.Pickups;
        float realDistance = (int)PlayerManager.Distance;
        int realScore = PlayerManager.Score;

        lives.text = "Lives: " + realLives;
        pickups.text = "Pickups: " + realPickups;
        distance.text = "Distance: " + realDistance;
        score.text = "Score: " + realScore;
    }
}
