using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] GameObject titleScreenPanel;
    [SerializeField] GameObject inGameUIPanel;
    [SerializeField]GameObject pauseMenuPanel;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject restartButton;
    
    [Header("Game Components")]
    [SerializeField] PlayerController playerController;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PauseManager pauseManager;

    [Header("Game Settings")]
    [SerializeField] float startTime = 5f;
    
    [Header("UI Text")]
    [SerializeField] TMP_Text timeText;
    
    float timeLeft;
    bool gameOver = false;

    bool isGameActive = false;
    public bool IsGameActive => isGameActive;

    public bool GameOver => gameOver;

    void Start() 
    {
        Time.timeScale = 0f; 
        isGameActive = false; 

        titleScreenPanel.SetActive(true);
        inGameUIPanel.SetActive(false);
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        playerController.enabled = false;
        pauseManager.enabled = false;
        pauseMenuPanel.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        isGameActive = true; 

        titleScreenPanel.SetActive(false);
        inGameUIPanel.SetActive(true);

        playerController.enabled = true;
        pauseManager.enabled = true;

        timeLeft = startTime;
        timeText.text = $"Time Left: {timeLeft.ToString("F1")}";
    }

    void Update()
    {
        if (gameOver || !isGameActive) return; 

        DecreaseTime();
    }

    public void IncreaseTime(float amount) 
    {
        timeLeft += amount;
        timeText.text = $"Time Left: {timeLeft.ToString("F1")}"; 
    }

    void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = $"Time Left: {timeLeft.ToString("F1")}"; 

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    public void PlayerGameOver() 
    {
        gameOver = true;
        pauseManager.enabled = false;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        inGameUIPanel.SetActive(false); 
        Time.timeScale = .1f; 
        
        scoreManager.CheckHighScore();
    }
}