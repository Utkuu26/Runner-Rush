using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject threeTxt;
    [SerializeField] private GameObject twoTxt;
    [SerializeField] private GameObject oneTxt;
    [SerializeField] private GameObject goTxt;
    [SerializeField] private GameObject fadeImg;
    [SerializeField] private GameObject bgImg;
    [SerializeField] private GameObject startBtn;
    [SerializeField] private GameObject scoreArea;
    [SerializeField] private ScoreGame scoreGameScript;

    public void StartGameBtn()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        bgImg.SetActive(false);
        startBtn.SetActive(false);
        fadeImg.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        threeTxt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        threeTxt.SetActive(false);
        twoTxt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        twoTxt.SetActive(false);
        oneTxt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        oneTxt.SetActive(false);
        goTxt.SetActive(true);
        scoreArea.SetActive(true);
        PlayerMovement.canMove = true;

        yield return new WaitForSeconds(1f); 
        fadeImg.SetActive(false); 
    }
}
