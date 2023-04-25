using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;


    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.SetText(playerScore.ToString());
        scoreText.GetComponent<TweenText>().TweenPunch();
    }
    [ContextMenu("Increase Score")]
    public void addScoreTest()
    {
        playerScore = playerScore + 1;
        scoreText.SetText(playerScore.ToString());
        scoreText.GetComponent<TweenText>().TweenPunch();

    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
