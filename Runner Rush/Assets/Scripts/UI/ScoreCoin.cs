using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreCoin : MonoBehaviour
{
    public static int coinAmount;
    [SerializeField] private TextMeshProUGUI coinAmountDisplay;
    [SerializeField] private TextMeshProUGUI endgameCoinAmountDisplay;

    void Start()
    {
        coinAmount = PlayerPrefs.GetInt("CoinAmount", 0);
    }

    void Update()
    {
        coinAmountDisplay.text = "Coins: " + coinAmount.ToString();
        endgameCoinAmountDisplay.text = "Coins: " + coinAmount.ToString();
        
        if(coinAmount > PlayerPrefs.GetInt("CoinAmount", 0))
        {
            ScoreGame.scoreAmount += 20;
            PlayerPrefs.SetInt("CoinAmount", coinAmount);
        }
    }

    public void AddCoins(int amount)
    {
        coinAmount += amount;
    }
}
