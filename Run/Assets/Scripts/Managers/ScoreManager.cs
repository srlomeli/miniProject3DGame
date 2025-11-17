using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    
    [SerializeField] TMP_Text highScoreText;
    int highScore = 0;
    private const string HIGH_SCORE_KEY = "HighScore";
    int score = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        UpdateHighScoreText();
        scoreText.text = $"Current Score: {score}";
    }

    public void IncreaseScore(int amount) 
    {
        if (gameManager.GameOver || !gameManager.IsGameActive) return;

        score += amount;
        scoreText.text = $"Current Score: {score}";
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {highScore}";
    }
}