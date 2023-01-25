using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private Score scoreboard;
    [SerializeField] private GameObject gameOverScreen;

    private bool isGameOver = false;
    private float score;
    
    public bool IsGameOver 
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    public float Score
    {
        get { return score; }
        set { score = value; }
    }

    private void Awake() 
    {
        Instance = this;    
    }
    
    public void UpdateScore(float newScore)
    {
        score += newScore;
        scoreboard.UpdateScoreTxt(score);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
