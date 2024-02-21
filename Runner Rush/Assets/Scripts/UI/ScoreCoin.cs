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
        
    }

    void Update()
    {
        coinAmountDisplay.text = "Coins: " + coinAmount.ToString();
        endgameCoinAmountDisplay.text = "Coins: " + coinAmount.ToString();
    }
}
