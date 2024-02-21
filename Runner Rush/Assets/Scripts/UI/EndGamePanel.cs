using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject scoreArea;

    void Start()
    {
        endGamePanel.SetActive(false);
        StartCoroutine(EndGameSequence());
    }

    IEnumerator EndGameSequence()
    {
        yield return new WaitForSeconds(3);
        scoreArea.SetActive(false);
        endGamePanel.SetActive(true);
    }

    public void TryAgainBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerMovement.canMove = false;
    }
}
