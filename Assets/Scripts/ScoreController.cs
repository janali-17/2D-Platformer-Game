using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        RefreshUI();
    }

    public void IncrementScore(int scoreIncrement)
    {
        score += scoreIncrement;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score : " + score;
    }
}
