using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
        PlayerPrefs.SetInt("CoinAmount", 0);
    }
}
