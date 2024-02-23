using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstackle : MonoBehaviour
{
    public GameObject player;
    public GameObject UIscoreArea;
    public GameObject Start_EndGame;

    void Start() 
    {
        player = GameObject.Find("Player");
        UIscoreArea = GameObject.Find("UIscoreArea");
        Start_EndGame = GameObject.Find("Start_EndGame");
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().Play("HittingAnim");
            UIscoreArea.GetComponent<ScoreGame>().enabled = false;
            Start_EndGame.GetComponent<EndGamePanel>().enabled = true;
        }
    }

}
