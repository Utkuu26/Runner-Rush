using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    void Start()
    {
        endGamePanel.SetActive(false);
        StartCoroutine(EndGameSequence());
    }

    IEnumerator EndGameSequence()
    {
        yield return new WaitForSeconds(3);
        endGamePanel.SetActive(true);
        int highestScore = PlayerPrefs.GetInt("HighestScore", ScoreGame.highestScore);
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    public void TryAgainBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerMovement.canMove = false;
        // PlayerPrefs.SetInt("CoinAmount", 0);
        // PlayerPrefs.SetInt("HighestScore", 0);
    }
}
