using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        ScoreCoin.coinAmount += 1;
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
