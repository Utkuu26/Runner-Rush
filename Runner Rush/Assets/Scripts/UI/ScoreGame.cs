using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreGame : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreDisplay;
   [SerializeField] private TextMeshProUGUI endgameScoreDisplay;
   [SerializeField] private TextMeshProUGUI highScoreDisplay;
   public static int scoreAmount;
   public bool increaseDistance = false;
   public static int highestScore;
   [SerializeField] private Color higherScoreColor;

   void Start()
   {
        scoreAmount = 0;
        // PlayerPrefs.GetInt() sadece bir kez çağrılmalı ve kaydedilen değer alınmalı
        highestScore = PlayerPrefs.GetInt("HighestScore", highestScore);
        // Alınan değer, highScoreDisplay içinde gösterilmeli
        highScoreDisplay.text = "High Score: " + highestScore.ToString();
   }

    void Update()
    {
        if(increaseDistance == false && PlayerMovement.canMove)
        {
            increaseDistance = true;
            StartCoroutine(IncreaseDistance()); 
        }

        // Her güncelleme döngüsünde en yüksek skoru kontrol ederek ekrana yazdır
        if (highestScore != PlayerPrefs.GetInt("HighestScore", highestScore))
        {
            highestScore = PlayerPrefs.GetInt("HighestScore", highestScore);
            highScoreDisplay.text = "High Score: " + highestScore.ToString();
        }
    }

    IEnumerator IncreaseDistance()
    {
        scoreAmount += 10;
        scoreDisplay.text = "Score: " + scoreAmount.ToString();
        endgameScoreDisplay.text = "Score: " + scoreAmount.ToString();
        if (scoreAmount > highestScore)
        {
            highestScore = scoreAmount;
            PlayerPrefs.SetInt("HighestScore", highestScore);
            highScoreDisplay.text = "High Score: " + highestScore.ToString();
        }
        yield return new WaitForSeconds(0.5f);
        increaseDistance = false;
    }
}
