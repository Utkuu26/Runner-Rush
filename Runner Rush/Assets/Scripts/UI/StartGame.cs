using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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


    void Start()
    {
        startBtn.SetActive(true);
        bgImg.SetActive(true);
        scoreArea.SetActive(false);
    }

    public void StartGameBtn()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        bgImg.SetActive(false);
        startBtn.SetActive(false);
        fadeImg.SetActive(true);
        threeTxt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        twoTxt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        oneTxt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        goTxt.SetActive(true);
        scoreArea.SetActive(true);
        PlayerMovement.canMove = true;
    }
}
