using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstackle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject UIscoreArea;
    [SerializeField] private GameObject EndgameArea;

    void OnTriggerEnter(Collider other) 
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().Play("HittingAnim");
        UIscoreArea.GetComponent<ScoreGame>().enabled = false;
        EndgameArea.GetComponent<EndGamePanel>().enabled = true;
    }

}
