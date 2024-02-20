using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreGame : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreDisplay;
   private int scoreAmount;
   public bool increaseDistance = false;

    void Update()
    {
        if(increaseDistance == false)
        {
            increaseDistance = true;
            StartCoroutine(IncreaseDistance()); 
        }
    }

    IEnumerator IncreaseDistance()
    {
        scoreAmount += 10;
        scoreDisplay.text = "Score: " + scoreAmount.ToString();
        yield return new WaitForSeconds(0.4f);
        increaseDistance = false;
    }
}
